<?xml version="1.0" encoding="utf-8"?>

<xs:stylesheet xmlns:xs="http://www.w3.org/1999/XSL/Transform" version="1.0"
               xmlns:pl="http://www.univ-grenoble-alpes.fr/l3miage/spacePeace/gameObjects">
    <xs:output method="html" indent="yes" encoding="UTF-8"/>

    <xs:template match="/">
        <html>
            <head>
                <meta charset="UTF-8"/>
                <link rel="stylesheet" href="../css/structure_xsl.css"/>
                <title>élément du jeux </title>
            </head>
            <body>
                <h1>Attributs du Playeur </h1>

                <table>
                    <thead>
                        <tr>
                            <th>Nom de la texture</th>
                            <th>Taille du playeur</th>
                            <th>Puissance du saut</th>
                            <th>Point de vie</th>
                        </tr>
                    </thead>
                    <tbody>
                        <xs:apply-templates select="//pl:Player">
                        </xs:apply-templates>
                    </tbody>
                </table>
            </body>
        </html>

    </xs:template>



    <xs:template match="pl:Player">
        <tr>
            <td>
                <xs:value-of select="pl:texture"/>
            </td>
            <td>
                <xs:value-of select="pl:height" />
            </td>
            <td>
                <xs:value-of select="pl:jumpForce" />
            </td>
            <td>
                <xs:value-of select="pl:ptVie" />

            </td>
        </tr>

    </xs:template>
</xs:stylesheet>