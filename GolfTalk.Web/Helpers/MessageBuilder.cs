using System;
using System.Text;

namespace GolfTalk.Helpers
{
    public static class MessageBuilder
    {
        public static string GetNewScoreMessage(int holeNumber, string teamName, int strokes, int par, int timezoneOffset)
        {
            var sb = new StringBuilder();
            var good = strokes <= par;

            sb.Append(good ? "Watch Out! " : "Cripes... ");

            sb.Append("<b>" + teamName + "</b> just ");

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

            sb.Append("hole " + holeNumber);
            sb.Append(" <i>@ " + DateTime.UtcNow.AddMinutes(-1 * timezoneOffset).ToShortTimeString() + "</i>");

            return sb.ToString();
        }
    }
}