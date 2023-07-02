using PhoneNumbers;
using System.Text.RegularExpressions;

namespace Crm.Api.Infrastruture.Helpers
{
    public static class ValidHelper
    {
        public static bool ValiderEmail(string email)
        {
            bool emailValide = true;

            try
            {
                System.Net.Mail.MailAddress mailAddress = new System.Net.Mail.MailAddress(email);
            }
            catch
            {
                emailValide = false;
            }

            if (emailValide)
            {
                // Deuxième test
                var r = new Regex(@"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$");
                emailValide = r.IsMatch(email);
            }

            return emailValide;
        }

        /// <summary>
        /// Vérification de la validité du téléphone
        /// </summary>
        /// <param name="valeur">Téléphone à vérifier</param>
        /// <returns>Téléphone valide ou pas</returns>
        public static bool ValiderTelephone(string valeur, string defaultRegion = "")
        {
            try
            {
                //Création de l'intance PhoneNumberUtil
                var util = PhoneNumberUtil.GetInstance();
                PhoneNumber number = null;
                //Si le numéro contient l'indicatif + ou le 00
                if (valeur.StartsWith("+") || valeur.StartsWith("00"))
                {
                    if (valeur.StartsWith("00"))
                    {
                        valeur = "+" + valeur.Remove(0, 2);
                    }

                    number = util.Parse(valeur, "");
                    // Récupération de la région au numéro avec l'indication +
                    string regionCode = util.GetRegionCodeForNumber(number);
                    // Validation du numéro qui correspond à la région trouvée
                    return util.IsValidNumberForRegion(number, regionCode);
                }
                else
                {
                    number = util.Parse(valeur, defaultRegion);
                    // Validation du numéro sans indication mais avec le region code
                    return util.IsValidNumber(number);
                }
            }
            catch (NumberParseException)
            {
                return false;
            }
        }
    }
}
