<?xml version="1.0" encoding="utf-8"?>

<xs:stylesheet xmlns:xs="http://www.w3.org/1999/XSL/Transform" version="1.0"
               xmlns:sa="http://www.univ-grenoble-alpes.fr/l3miage/spacePeace/Saves">
    <xs:output method="html" indent="yes" encoding="UTF-8"/>

    <xs:template match="/">
        <html>
            <head>
                <meta charset="UTF-8"/>
                <link rel="stylesheet" href="../css/structure_xsl.css"/>
                <title>Hi-Scores </title>
            </head>
            <body>
                <h1>Hi-Scores</h1>

                <table>
                    <thead>
                        <tr>
                            <th>Nom du joueur</th>
                            <th>Score</th>
                            <th>Niveau atteint</th>
                            <th>Date</th>
                        </tr>
                    </thead>
                    <tbody>
                        <xs:apply-templates select="//sa:SaveInstance">
                            <xs:sort select="sa:Score" order="descending"/>
                        </xs:apply-templates>
                    </tbody>
                </table>
            </body>
        </html>

    </xs:template>



    <xs:template match="sa:SaveInstance">
        <tr>
            <td>
                <xs:value-of select="sa:PlayerName"/>
            </td>
            <td>
                <xs:value-of select="sa:Score" />
            </td>
            <td>
                <xs:value-of select="sa:Niveau" />
            </td>
            <td>
                <xs:value-of select="sa:Date" />
            </td>
        </tr>

    </xs:template>
</xs:stylesheet>