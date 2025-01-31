﻿using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using dominio;
using FinalProyect_MaxiPrograma_LVL3.dominio;
using negocio;

namespace FinalProyect_MaxiPrograma_LVL3.negocio
{
    public class UserNegocio
    {
        public bool login(UserClass user)
        {
            DataAccess data = new DataAccess();
            try
            {
                data.settingQuery("select id, nombre,  apellido, urlImagenPerfil, admin  from USERS where @email=email and @pass = pass");
                data.settingParametter("@Email", user.Email);
                data.settingParametter("@pass", user.Password);

                data.executeQuery();
                while (data.Reader.Read())
                {
                    user.Id = (int)data.Reader["id"];
                    user.TypeUser = (bool)data.Reader["admin"] ? typeUser.Admin : typeUser.User;
                    if (data.Reader["nombre"] is DBNull)
                        user.UserName = "No Name";
                    else
                        user.UserName = (string)data.Reader["nombre"];
                    if (data.Reader["apellido"] is DBNull)
                        user.UserSurname = "No Surname";
                    else
                        user.UserSurname = (string)data.Reader["apellido"];
                    if (data.Reader["UrlImagenPerfil"] is DBNull)
                        user.UrlImagen = "./Images/profile-"+user.Id+".png";
                    else
                        user.UrlImagen = (string)data.Reader["UrlImagenPerfil"];

                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                data.closeConnection();
            }
        }
        public int register(UserClass user)
        {
            int userID = 0;
            DataAccess data = new DataAccess();
            try
            {
                data.settingQuery("insert into USERS (email,pass,nombre,apellido,urlImagenPerfil,admin) values (@email,@pass,@nombre,@apellido,@url,@admin); SELECT SCOPE_IDENTITY();");
                data.settingParametter("@email", user.Email);
                data.settingParametter("@pass", user.Password);
                data.settingParametter("@admin", user.TypeUser == typeUser.Admin ? 1 : 0);
                data.settingParametter("@url", user.UrlImagen);
                data.settingParametter("@nombre", user.UserName);
                data.settingParametter("@apellido", user.UserSurname);
                userID = Convert.ToInt32(data.executeScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                data.closeConnection();
            }
            return userID;
        }
        public void correctImageUrl(int idUser)
        {
            DataAccess data = new DataAccess();
            try
            {
                data.settingQuery("update USERS set urlImagenPerfil = @url where id = @id");
                data.settingParametter("@id", idUser);
                data.settingParametter("@url", "./Images/profile-" + idUser + ".png");
                data.executeQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                data.closeConnection();
            }
        }
        public void modify(UserClass user)
        {
            DataAccess data = new DataAccess();
            try
            {
                data.settingQuery("update USERS set email = @email, pass = @pass, admin = @type, urlImagenPerfil=@img, nombre = @nombre, apellido = @apellido where id = @id");
                data.settingParametter("@id", user.Id);
                data.settingParametter("@email", user.Email);
                data.settingParametter("@pass", user.Password);
                data.settingParametter("@type", user.TypeUser == typeUser.Admin ? 1 : 0);
                data.settingParametter("@img", user.UrlImagen);
                data.settingParametter("@nombre", user.UserName);
                data.settingParametter("@apellido", user.UserSurname);
                data.executeQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                data.closeConnection();
            }
        }
        public UserClass getUser(int id)
        {
            DataAccess data = new DataAccess();
            try
            {
                data.settingQuery("select id, email, pass, admin, urlImagenPerfil, nombre, apellido from USERS where id = @id");
                data.settingParametter("@id", id);
                data.executeQuery();
                while (data.Reader.Read())
                {
                    UserClass user = new UserClass();
                    user.Id = (int)data.Reader["id"];
                    user.Email = (string)data.Reader["email"];
                    user.Password = (string)data.Reader["pass"];
                    user.TypeUser = (bool)data.Reader["admin"] ? typeUser.Admin : typeUser.User;
                    if (data.Reader["nombre"] is DBNull)
                        user.UserName = "No Name";
                    else
                        user.UserName = (string)data.Reader["nombre"];
                    if (data.Reader["apellido"] is DBNull)
                        user.UserSurname = "No Surname";
                    else
                        user.UserSurname = (string)data.Reader["apellido"];
                    if (data.Reader["UrlImagenPerfil"] is DBNull)
                        user.UrlImagen = "/Images/Default.png";
                    else
                        user.UrlImagen = (string)data.Reader["UrlImagenPerfil"];
                    return user;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                data.closeConnection();
            }
        }
    }
}