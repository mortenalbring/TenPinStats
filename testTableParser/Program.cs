using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;

namespace testTableParser
{
    public class Program
    {
        public static void Main()
        {

            //Load document from XML document 
            var xmlDocument = new XmlDocument();
            xmlDocument.Load("Lane10.xml");

           
            //Find the table corner with the string 'Player'
            var tableCorners = FindString(xmlDocument, "Player");
            tableCorners = tableCorners.OrderByDescending(e => e.BBox.y0).ToList();

            foreach (var corner in tableCorners)
            {
                //Find the headers
                var tableHeaders = FindWithMatchingYCoordinate(xmlDocument, corner.BBox.y0).OrderBy(e => e.BBox.x0).ToList();

                var matchingX = FindWithMatchingXCoordinate(xmlDocument, corner.BBox.x0);
                var orderedMatchingX = matchingX.OrderBy(e => e.BBox.y0).ToList();


                var players = new List<PdfXmlItem>();
                foreach (var ord in orderedMatchingX)
                {
                    if (ord.Title == "Player")
                    {
                        break;
                    }

                    players.Add(ord);
                }

                players = players.OrderByDescending(e => e.BBox.y0).ToList();

                

                foreach (var player in players)
                {
                
    

                    foreach (var header in tableHeaders)
                    {
                        var scores = FindWithMatchingXCoordinate(xmlDocument, header.BBox.x0,20);

                        var orderedScores = scores.OrderBy(e => e.BBox.y0).ToList();

                        var matchingScores = FindWithMatchingYCoordinate(player, scores);

                        
                        var xxxxxxxxxxxxxxxxx = 42;
                    }

                    





                    var xxxxxx = 42;


                }


                var xxx = 42;

            }


        }


        public static List<PdfXmlItem> FindString(XmlDocument xmlDocument, string searchString)
        {
            var matches = new List<PdfXmlItem>();
            foreach (XmlNode xmlNode in xmlDocument.ChildNodes)
            {
                foreach (XmlNode page in xmlNode.ChildNodes)
                {
                    foreach (XmlNode textbox in page.ChildNodes)
                    {
                        foreach (XmlNode textline in textbox.ChildNodes)
                        {
                            var textlinevalue = "";

                            foreach (XmlNode text in textline.ChildNodes)
                            {
                                textlinevalue = textlinevalue + text.InnerText;
                            }

                            if (textlinevalue == searchString)
                            {
                                var bbox = textline.Attributes["bbox"].Value.Split(',');

                                var newmatch = new PdfXmlItem();

                                newmatch.Title = textlinevalue;

                                var playerCodeBB = new BoundingBox();
                                playerCodeBB.x0 = Convert.ToDouble(bbox[0]);
                                playerCodeBB.y0 = Convert.ToDouble(bbox[1]);

                                playerCodeBB.x1 = Convert.ToDouble(bbox[2]);
                                playerCodeBB.y1 = Convert.ToDouble(bbox[3]);


                                newmatch.BBox = playerCodeBB;

                                matches.Add(newmatch);


                            }

                        }

                    }

                }
            }
            return matches;
        }


        public static List<PdfXmlItem> FindWithMatchingYCoordinate(PdfXmlItem item, List<PdfXmlItem> possibleMatches, double threshold = 10)
        {
            var actualMatches = new List<PdfXmlItem>();
            foreach (var poss in possibleMatches)
            {
                if (Math.Abs(poss.BBox.y0 - item.BBox.y0) < threshold)
                {
                    actualMatches.Add(poss);
                }
            }
            return actualMatches;
        }

        public static List<PdfXmlItem> FindWithMatchingXCoordinate(PdfXmlItem item, List<PdfXmlItem> possibleMatches,double threshold=10)
        {
            var actualMatches = new List<PdfXmlItem>();
            foreach (var poss in possibleMatches)
            {
                if (Math.Abs(poss.BBox.x0 - item.BBox.x0) < threshold)
                {
                    actualMatches.Add(poss);
                }
            }
            return actualMatches;
        }

        public static List<PdfXmlItem> FindWithMatchingXCoordinate(XmlDocument xmlDocument, double matchx0,double threshold=10)
        {
            var matchingItems = new List<PdfXmlItem>();
            foreach (XmlNode xmlNode in xmlDocument.ChildNodes)
            {
                foreach (XmlNode page in xmlNode.ChildNodes)
                {
                    foreach (XmlNode textbox in page.ChildNodes)
                    {
                        foreach (XmlNode textline in textbox.ChildNodes)
                        {
                            var textlinevalue = textline.ChildNodes.Cast<XmlNode>().Aggregate("", (current, text) => current + text.InnerText);

                            if (textline.Attributes["bbox"] == null) continue;
                            var bbox = textline.Attributes["bbox"].Value.Split(',');

                            var textlineitem = new PdfXmlItem();

                            textlineitem.Title = textlinevalue;

                            textlineitem.BBox.x0 = Convert.ToDouble(bbox[0]);
                            textlineitem.BBox.y0 = Convert.ToDouble(bbox[1]);

                            textlineitem.BBox.x1 = Convert.ToDouble(bbox[2]);
                            textlineitem.BBox.y1 = Convert.ToDouble(bbox[3]);

                            if (Math.Abs(textlineitem.BBox.x0 - matchx0) < threshold)
                            {
                                matchingItems.Add(textlineitem);
                            }
                        }

                    }

                }
            }
            return matchingItems;
        }

        public static List<PdfXmlItem> FindWithMatchingYCoordinate(XmlDocument xmlDocument, double matchy0,double threshold=10)
        {
            var matchingItems = new List<PdfXmlItem>();
            foreach (XmlNode xmlNode in xmlDocument.ChildNodes)
            {
                foreach (XmlNode page in xmlNode.ChildNodes)
                {
                    foreach (XmlNode textbox in page.ChildNodes)
                    {
                        foreach (XmlNode textline in textbox.ChildNodes)
                        {
                            var textlinevalue = textline.ChildNodes.Cast<XmlNode>().Aggregate("", (current, text) => current + text.InnerText);

                            if (textline.Attributes["bbox"] == null) continue;
                            var bbox = textline.Attributes["bbox"].Value.Split(',');

                            var textlineitem = new PdfXmlItem();

                            textlineitem.Title = textlinevalue;

                            textlineitem.BBox.x0 = Convert.ToDouble(bbox[0]);
                            textlineitem.BBox.y0 = Convert.ToDouble(bbox[1]);

                            textlineitem.BBox.x1 = Convert.ToDouble(bbox[2]);
                            textlineitem.BBox.y1 = Convert.ToDouble(bbox[3]);

                            if (Math.Abs(textlineitem.BBox.y0 - matchy0) < threshold)
                            {                                   
                                matchingItems.Add(textlineitem);
                            }
                        }

                    }

                }
            }
            return matchingItems;
        }


    }
}
