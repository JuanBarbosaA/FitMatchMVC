using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;


namespace CapaNegocio
{
    public class CN_Cliente
    {

        private CD_Cliente objCapaDato = new CD_Cliente();


        public int Registrar(Cliente obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (string.IsNullOrEmpty(obj.Nombres) || string.IsNullOrWhiteSpace(obj.Nombres))
            {
                Mensaje = "El nombre del cliente no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Apellidos) || string.IsNullOrWhiteSpace(obj.Apellidos))
            {
                Mensaje = "El apellido del cliente no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Correo) || string.IsNullOrWhiteSpace(obj.Correo))
            {
                Mensaje = "El correo del cliente no puede ser vacio";
            }


            if (string.IsNullOrEmpty(Mensaje))
            {

                obj.Clave = CN_Recursos.ConvertirSha256(obj.Clave);
                return objCapaDato.Registrar(obj, out Mensaje);

            }
            else
            {
                return 0;
            }
        }


        public List<Cliente> Listar()
        {
            return objCapaDato.Listar();
        }




        public bool CambiarClave(int idcliente, string nuevaclave, out string Mensaje)
        {
            return objCapaDato.CambiarClave(idcliente, nuevaclave, out Mensaje);
        }



        public bool ReestablecerClave(int idcliente, string correo, out string Mensaje)
        {
            Mensaje = string.Empty;
            string nuevaclave = CN_Recursos.GenerarClave();
            bool resultado = objCapaDato.ReestablecerClave(idcliente, CN_Recursos.ConvertirSha256(nuevaclave), out Mensaje);


            if (resultado)
            {
                string asunto = "Contraseña Reestablecida";
                string mensaje_correo;


                mensaje_correo = "< html >< head >< meta http - equiv = 'Content-Type' content = 'text/html; charset=UTF-8' />< link href = 'https://fonts.googleapis.com/css2?family=Degraular:wght@400;500;700&display=swap' rel = 'stylesheet' >< link rel = 'stylesheet' href = 'https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/css/all.min.css' >< style type = 'text/css' >/*global*/@font - face { font - family: 'Degraular'; src: url('fonts/Degraular-Bold.woff2') format('woff2'),url('fonts/Degraular-Bold.woff') format('woff'); font - weight: 700; font - style: normal; } table,body,td,input,textarea,select,p,ul,ol,li {color: #555d63;font-family: arial, sans-serif;font-size: 15px;line-height: 150%;}table {border-collapse: collapse;border-spacing: 0;}body {font-size: 15px;text-align: left;-webkit-text-size-adjust: none;margin: 0;padding-left: 0;width: 100% !important;background-color: #eeeeee;}.main {width: 100%;max-width: 600px;}img {border: 0;height: auto;line-height: 100%;outline: none;text-decoration: none;}.profile-pic-container {display: flex;margin-bottom: 25px;}.profile-pic-container img {border-radius: 50%;border: 1px solid #d8d8d8;margin-right: 15px;width: 81px;}.profile-pic-container .extra-candidates {background-color: #0b7d98;border-radius: 50%;width: 81px;height: 81px;display: flex;justify-content: center;align-items: center;color: #ffffff;border: 1px solid #d8d8d8;}.profile-pic-container .extra-candidates-text {display: flex;flex-direction: column;justify-content: center;align-items: center;}.profile-pic-container figure {margin: 0;text-align: center;}.profile-pic-container figcaption {width: 90px;text-align: inherit;margin: 0 auto;}/*main table styling*/#backgroundTable {height: 100%;margin: 0 15px;padding: 0;max-width: 640px;min-width: 315px;background-color: transparent;}/*header*/hr {size: 1px;color: #077c99;}h1,.h1 {color: #077c99;display: block;font-family: 'helvetica neue', 'helvetica', arial, sans-serif;font-size: 28px;font-weight: bold;line-height: 130%;margin-top: 0;margin-right: 0;margin-bottom: 20px;margin-left: 0;text-align: left;}h2,.h2 {color: #077c99;display: block;font-family: 'helvetica neue', 'helvetica', arial, sans-serif;font-size: 24px;font-weight: bold;line-height: 130%;margin-top: 0;margin-right: 0;margin-bottom: 20px;margin-left: 0;text-align: left;}h3,.h3 {color: #077c99;display: block;font-family: 'helvetica neue', 'helvetica', arial, sans-serif;font-size: 18px;font-weight: bold;line-height: 120%;margin-top: 0;margin-right: 0;margin-bottom: 10px;margin-left: 0;text-align: left;}h4,.h4 {color: #4b4b4b;display: block;font-family: 'helvetica neue', 'helvetica', arial, sans-serif;font-size: 16px;font-weight: bold;line-height: 120%;margin-top: 0;margin-right: 0;margin-bottom: 5px;margin-left: 0;text-align: left;}#templateHeader {background-color: #ffffff;border-bottom: 0;width: 100%;}#templateHeader .headerContent1 {line-height: 0;width: 50%;height: 112px;padding: 0px 48px}#templateHeader .headerTitle {float: right;font-size: 12px;margin-top: 16px;color: #9b9b9b;}#headerImage {padding-top: 5px;}/*main content area*/a:link,a:visited,a .yshortcuts {color: #16bed4;font-weight: bold;text-decoration: none;}h1 a,h1 a:link,h1 a:visited,h2 a,h2 a:link,h2 a:visited {color: #077c99;}h1 a:hover,h2 a:hover {color: #16bed4;}a.no-bold {font-weight: normal;text-decoration: underline;}p {font-size: 15px;line-height: 22px;}p.intro-text {font-size: 18px;line-height: 28px;}/*button1 style*/p.button {margin: 25px 0;}p.button a {color: #ffffff;font-size: 16px;-webkit-border-radius: 7px;-moz-border-radius: 7px;border-radius: 7px;background-color: #077c99;text-align: center;text-decoration: none;padding: 8px 17px 8px 17px;}/*button2 style*//*p.button2 {*/ /*  margin-top: 35px;*/ /*  margin-bottom: 35px;*/ /*}*//*p.button2 a {*/ /*  color:#FFFFFF;*/ /*  font-size:16px;*/ /*  background-color:#FBAC03;*/ /*  text-align:center;*/ /*  text-decoration:none;*/ /*  letter-spacing: 1px;*//*  padding: 21px 28px;*/ /*  box-shadow: 0px 2px 4px 0px rgba(0,0,0,0.25);*//*}*//*a.button3 {*/ /*    border-radius: 4px;*/ /*    background-color: #077C99;*/ /*    color: white;*/ /*    font-size: 15px;*/ /*    padding: 14px 40px;*/ /*    line-height: 20px;*/ /*    text-align: center;*/ /*    font-weight: normal;*/ /*    display: inline-block;*//*}*//*particular to certain emails*//*.feature {*/ /*  border-bottom: 10px solid transparent;*/ /*}*//*.feature > table {*/ /*  background-color: #f8fcfd;*/ /*}*//*.feature .featureImage img {*/ /*  border: 1px solid #AAA;*/ /*}*//*.feature .featureContent {*/ /*  padding-left: 0;*/ /*}*//*.embedded-note {*/ /*  color: #21a1ba;*/ /*  font-style: italic;*//*  white-space: pre-wrap;*/ /*  unicode-bidi: embed;*//*  max-width: 350px;*/ /*  border-left: 4px solid #C7E5E9;*/ /*  padding-left: 19px;*/ /*  padding-right: 16px;*//*  margin: 19px 0 20px 39px;*//*}*//*.detail-descriptors {*/ /*  color: #207e98;*/ /*  font-weight: bold;*/ /*  line-height: 200%;*//*}*//#outlook a{/*  padding:0;*//*}*//*.ReadMsgBody{*/ /*  width:100%;*//*}*//*.ExternalClass{*/ /*  width:100%;*//*}*//*.feature2 {*/ /*    border-top: 1px solid #eeeeee;*/ /*    padding: 20px 25px;*/ /*    min-height: 250px;*//*}/*a.link-button, a.link-button:visited {*/ /*    border: 1px solid #025669;*/ /*    color: #024656;*/ /*    text-align: center;*/ /*    text-decoration: none;*/ /*    display: inline-block;*/ /*    background-color: #FFFFFF;*/ /*    width: 40px;*/ /*    height: 40px;*/ /*    border-radius: 4px;*/ /*    box-sizing: border-box;*/ /*    margin-right: 6px;*/ /*    padding: 8px;*/ /*}/*a.link-button:hover, a.link-button:active {*/ /*  background-color: #025669;*/ /*  color: #FFFFFF;*/ /*}*//*.panel {*/ /*    width: 100%;*/ /*    border: 1px solid #D8D8D8;*/ /*    background-color: rgba(7,124,153,0.05);*/ /*    display: block;*/ /*    margin-bottom: 15px;*/ /*}*//*footer*//*table details*/table.details {margin: 0 auto 30px auto;width: 100%;}table.details th,table.details td {padding-right: 10px;text-align: left;}table.details td {padding-top: 10px;}/*.footer1Content, .footer1Content td {*//*  text-align: center;*//*}/*/*.footer1Content a:link, .footer1Content a:visited, .footer1Content a {*//*  color: white;*//*  font-weight: normal;*//*}*//*#templateFooter2{*//*  background-color: white;*//*  border-top:0;*//*  font-size: 15px;*//*  line-height: 22px;*//*  width: 100%;*//*  padding-top: 20px;*//*}/*/*.footer2Content {*//*  text-align: left;*//*  color: #4b4b4b;*//*  padding-left: 300px;*//*}/*#templateFooter3{*//*background-color: white;*//*  border-top:0;*//*  font-size: 12px;*//*  line-height: 22px;*//*  width: 100%;*//*  padding: 0;*//*  padding-left: 50px*//*  padding-right: 50px*//*  vertical-align: bottom;*//*position: fixed;*//*  bottom: 0px;*//*  height:52px;*//*border-bottom: 5px solid #C7E5E9;*//*}/*#templateFooter3 td {*//*    padding: 10px 0 0 0;*//*}*//*.footer3Content1 {*//*  text-align: center;*//*  color: #A9AdAe;*//*padding-left: 45px;*//*  min-width: 90px;*//*}*//*.footer3Content1 a {*//*  margin-right: 4px;*//*}*//*.footer3Content1 .footerSocialLink {*//*    background-color: #077c99;*//*    height: 20px;*//*    width: 20px;*//*    display: inline-block;*//*    background-repeat: no-repeat;*//*    background-size: 50% !important;*//*    background-position: 50%;*//*    border-radius: 999px*//*}*//*.footer3Content1 .footerSocialLink.facebook {*//*    background-image: url(https://www.filepicker.io/api/file/4xAQanUTtOgYK4kcaHmp);*//*}*//*.footer3Content1 .footerSocialLink.linkedin {*//*    background-image: url(https://www.filepicker.io/api/file/ihRp44HbRPeSUtfLoBKZ);*//*}*//*.footer3Content1 .footerSocialLink.twitter {*//*    background-image: url(https://www.filepicker.io/api/file/08tkDstbTLObSmpGBufD);*//*}*//*.footer3Content2, .footer3Content2 td {*//*  text-align: right;*//*  color: #A9AdAe;*//*  padding-right: 50px;*//*}/*/*.footer3Content2 a:link, .footer3Content2 a:visited, .footer3Content2 a {*//*  color: #A9AdAe;*//*  font-weight: normal;*//*}*//*.bodyContent {*//*  background-color: white;*//*  text-align: left;*//*  padding: 0px 48px 0px 48px;*//*}*//*.bodyContent img {*//*  max-width: 560px;*//*  height: auto;*//*}*//*.content {*//*  border: 3px solid #ebebeb;*//*  padding: 48px;*//*  min-height: 200px;*//*  border-radius: 24px;*//*  box-shadow: 0px 1px 1px rgba(235,235,235);*//*}*//*.content .headline{*//*  font-weight: 400;*//*  font-size: 22px;*//*  font-family: 'Degraular', sans-serif;*//*  letter-spacing: -1px;*//*  line-height: 30px;*//*  text-align: center;*//*}*//*.content p {*//*  font-size: 1rem;*//*  color: #141414;*//*  font-weight: 400;*//*  margin-bottom: 3px;*//*  *//*}*//*.space-1 {*//*  height: 10px;*//*}*//*.space-2 {*//*  height: 20px;*//*}/*.button2 {  /*  border: 2px solid #141414;  /*  color: #141414;  /*  text-align: center;  /*  text-decoration: none;  /*  display: inline-block;  /*  border-radius: 0.571rem;  /*  box-sizing: border-box;  /*  cursor: pointer;  /*  box-shadow: 0px 2px 0px rgba(0, 0, 0, 1);  /*  padding: 0.571rem 1.143rem;}/*.button2:hover{  /*  box-shadow: 0px 2px 0px white;}*//*.bodyContent a:link {*//*  color: #141414;*//*  font-weight: normal;*//*  text-decoration: underline;*//*}*//*.bodyContent a:visited {*//*  color: #141414;*//*  font-weight: normal;*//*  text-decoration: underline;*//*}*//*.bodyContent a .yshortcuts {*//*  color: #141414;*//*  font-weight: normal;*//*  text-decoration: underline;*//*}*//*.bodyContent a {*//*  color: #141414;*//*  font-weight: normal;*//*  text-decoration: underline;*//*}*//*.bodyContent img {*//*  display: inline;*//*  height: auto;*//*  max-width: 560px;*//*}/*.footerContent {*//*  background-color: white;*//*  text-align: left;*//*  padding: 20px;*//*}*//*.footerContent a:link,.footerContent a:visited,.footerContent a .yshortcuts {*//*  color: #16bed4;*//*  font-weight: normal;*//*  text-decoration: underline;*//*}*//*.footerContent img {*//*  display: inline;*//*}/*.footerContent p {*//*  color: #4b4b4b;*//*  font-size: 12px;*//*  line-height: 20px;*//*  margin-bottom: 0;*//*}/*.footerContent .social{margin: 1rem auto;display: flex;justify-content: center;align-items: center;}.footerContent .social a{text-decoration: none;color: #141414;padding: 0 0.5rem;transition: color 0.2s ease;}.footerContent .social a:hover{color: #3de07e;}.footerContent .privacy{text-align: center;margin-top: 2rem;color: #9b9b9b;}";





                mensaje_correo = mensaje_correo.Replace("¡clave!", nuevaclave);

                bool respuesta = CN_Recursos.EnviarCorreo(correo, asunto, mensaje_correo);

                if (respuesta)
                {
                    return true;
                }
                else
                {
                    Mensaje = "No se pudo enviar el correo";
                    return false;
                }
            }
            else
            {
                Mensaje = "No se pudo reestablecer la contraseña";
                return false;
            }

        }

    }
}
