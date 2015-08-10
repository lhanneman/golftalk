using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace GolfTalk.Helpers
{
    public static class MessageBuilder
    {
        public static string GetNewScoreMessage(int holeNumber, string teamName, int strokes, int par)
        {
            StringBuilder sb = new StringBuilder();
            bool good = strokes <= par;

            if (good)
            {
                sb.Append("Watch Out! ");
            }
            else
            {
                sb.Append("Uh oh... ");
            }

            sb.Append("<b>" + teamName + "</b> just ");

            #region get golf term for score
            if (good)
            {
                if (strokes == par)
                {
                    sb.Append("parred ");
                }
                else if (strokes == (par - 1))
                {
                    sb.Append("BIRDIED ");
                }
                else if (strokes == (par - 2))
                {
                    if (par > 3)
                    {
                        sb.Append("EAGLED ");
                    }
                    else
                    {
                        sb.Append("got a " + strokes + " on ");
                    }
                }
                else if (strokes == (par - 3))
                {
                    if (par > 3)
                    {
                        sb.Append("DOUBLE EAGLED ");
                    }
                    else
                    {
                        sb.Append("got a " + strokes + " ");
                    }
                }
                else
                {
                    sb.Append("got a " + strokes + " ");
                }
            }
            else
            {
                if (strokes == (par + 1))
                {
                    sb.Append("bogied ");
                }
                else if (strokes == (par + 2))
                {
                    sb.Append("double bogied ");
                }
                else if (strokes == (par + 3))
                {
                    sb.Append("triple bogied ");
                }
                else
                {
                    sb.Append("went " + (strokes - par) + " over on ");
                }
            }

            #endregion

            sb.Append("hole " + holeNumber);

            //sb.Append(" <span class='feed-item-suffix'>@ " + DateTime.Now.ToShortTimeString() + "</span");
            sb.Append(" <i>@ " + DateTime.Now.ToShortTimeString() + "</i>");

            return sb.ToString();

        }

       

       
    }
}