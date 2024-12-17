<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0"
                xmlns:go="http://www.univ-grenoble-alpes.fr/l3miage/spacePeace/GameOne"
                xmlns:pl="http://www.univ-grenoble-alpes.fr/l3miage/spacePeace/gameObjects"
                xmlns:en="http://www.univ-grenoble-alpes.fr/Enemy"
                xmlns:sp="http://www.univ-grenoble-alpes.fr/l3miage/spacePeace/animatedSprites">
    <xsl:output method="html" indent="yes" encoding="UTF-8"/>

    <!-- Template pour la structure HTML complète -->
    <xsl:template match="/">
        <html>
            <head>
                <meta charset="UTF-8"/>
                <link rel="stylesheet" href="../css/structure_xsl.css"/>
                <title>Éléments du jeu</title>
            </head>
            <body>
                <l1>Nous allons vous présenter quelques attributs de nos différentes classes !</l1>
                <h1>Attributs du Joueur</h1>
                <table>
                    <thead>
                        <tr>
                            <th>Puissance du saut</th>
                            <th>Points de vie</th>
                        </tr>
                    </thead>
                    <tbody>
                        <!-- Application des templates pour chaque Player -->
                        <xsl:apply-templates select="//go:Player"/>
                    </tbody>
                </table>

                <h1>Attributs de l'Ennemi</h1>
                <table>
                    <thead>
                        <tr>
                            <th>Points de vie</th>
                            <th>Dégâts</th>
                        </tr>
                    </thead>
                    <tbody>
                        <!-- Application des templates pour chaque Enemy -->
                        <xsl:apply-templates select="//go:Enemy"/>
                        <xsl:value-of select="go:Enemy/go:Degats"/>
                    </tbody>
                </table>

                <h1>Attributs d'un Sprite</h1>
                <table>
                    <thead>
                        <tr>
                            <th>Texture</th>
                            <th>Hauteur</th>
                            <th>Largeur</th>
                        </tr>
                    </thead>
                    <tbody>
                        <!-- Application des templates pour chaque Sprite -->
                        <xsl:apply-templates select="//go:Sprite"/>
                    </tbody>
                </table>
            </body>
        </html>
    </xsl:template>

    <!-- Template pour chaque Player -->
    <xsl:template match="go:Player">
        <tr>
            <td><xsl:value-of select="pl:jumpForce"/></td>
            <td><xsl:value-of select="pl:ptVie"/></td>
        </tr>
    </xsl:template>

    <!-- Template pour chaque Enemy -->
    <xsl:template match="go:Enemy">
        <tr>
            <td><xsl:value-of select="en:Pv"/></td>
            <td><xsl:value-of select="en:Degats"/></td>
        </tr>
    </xsl:template>

    <!-- Template pour chaque Sprite -->
    <xsl:template match="go:Sprite">
        <tr>
            <td><xsl:value-of select="sp:texture"/></td>
            <td><xsl:value-of select="sp:height"/></td>
            <td><xsl:value-of select="sp:wigth"/></td>
        </tr>
    </xsl:template>

</xsl:stylesheet>
