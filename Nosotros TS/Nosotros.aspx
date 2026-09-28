<%@ Page Title="Nosotros" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Nosotros.aspx.cs" Inherits="Nosotros" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<section class="hero-nosotros">

    <div class="hero-texto">

        <span>CONOCE NUESTRA ESENCIA</span>

        <h1>
            Más que tecnología,
            personas y <b>propósito.</b>
        </h1>

        <p>
            Somos un equipo apasionado por la innovación,
            comprometido en transformar ideas en soluciones
            digitales que generan un impacto real.
        </p>

        <br />

        <a class="btn-principal">
            Conoce nuestro trabajo →
        </a>

    </div>

</section>

<section class="quienes">

    <div>

        <span>QUIÉNES SOMOS</span>

        <h2>
            Impulsamos el futuro
            a través de la <b>tecnología</b>
        </h2>

        <p>
            Somos una empresa dedicada al desarrollo de software
            y soluciones digitales, con el objetivo de ayudar a
            organizaciones a crecer, optimizar sus procesos y
            enfrentar los desafíos actuales.
        </p>

        <br />
        <a class="btn-secundario">
            Nuestra historia →
        </a>

    </div>


    <div class="imagen">

        <img src="Images/oficina.png" />

    </div>

</section>

<section class="valores">

    <span>NUESTROS VALORES</span>

    <h2>Lo que nos impulsa</h2>


    <div class="cards">

        <div class="valor">

    <div class="icono-valor">
        <i class="bi bi-lightbulb"></i>
    </div>

    <h3>Innovación</h3>

    <p>
        Buscamos nuevas formas de crear soluciones.
    </p>

</div>


        <div class="valor">

    <div class="icono-valor">
        <i class="bi bi-people"></i>
    </div>

    <h3>Trabajo en equipo</h3>

    <p>
        Creemos en la colaboración.
    </p>

</div>


        <div class="valor">

    <div class="icono-valor">
        <i class="bi bi-shield-check"></i>
    </div>

    <h3>Compromiso</h3>

    <p>
        Nos involucramos en cada proyecto.
    </p>

</div>


        <div class="valor">

    <div class="icono-valor">
        <i class="bi bi-bar-chart"></i>
    </div>

    <h3>Crecimiento</h3>

    <p>
        Buscamos mejorar constantemente.
    </p>

</div>
        </div>

    <p class="frase-final">"La tecnología es más poderosa cuando se construye con propósito.</p>
<div class="linea-final"></div>

</section>

</asp:Content>