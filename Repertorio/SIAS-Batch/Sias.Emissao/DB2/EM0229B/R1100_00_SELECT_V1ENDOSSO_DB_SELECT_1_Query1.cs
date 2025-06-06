using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0229B
{
    public class R1100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1 : QueryBasis<R1100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE ,
            NRENDOS ,
            FONTE ,
            NRPROPOS ,
            QTPARCEL ,
            DTEMIS ,
            ORGAO ,
            RAMO ,
            CORRECAO ,
            COD_MOEDA_PRM ,
            CODCLIEN ,
            OCORR_ENDERECO,
            CODSUBES ,
            VALUE(CODPRODU,0),
            TIPAPO
            INTO :V1ENDO-NUMAPOL ,
            :V1ENDO-NRENDOS ,
            :V1ENDO-FONTE ,
            :V1ENDO-NRPROPOS ,
            :V1ENDO-QTPARCEL ,
            :V1ENDO-DTEMIS ,
            :V1ENDO-ORGAO ,
            :V1ENDO-RAMO ,
            :V1ENDO-CORRECAO ,
            :V1ENDO-CODUNIMO ,
            :V1ENDO-CODCLIEN ,
            :V1ENDO-OCORR-END,
            :V1ENDO-CODSUBES ,
            :V1ENDO-CODPRODU ,
            :V1ENDO-TIPAPO
            FROM SEGUROS.V1ENDOSSO
            WHERE NUM_APOLICE = :V1EDIA-NUMAPOL
            AND NRENDOS = :V1EDIA-NRENDOS
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE 
							,
											NRENDOS 
							,
											FONTE 
							,
											NRPROPOS 
							,
											QTPARCEL 
							,
											DTEMIS 
							,
											ORGAO 
							,
											RAMO 
							,
											CORRECAO 
							,
											COD_MOEDA_PRM 
							,
											CODCLIEN 
							,
											OCORR_ENDERECO
							,
											CODSUBES 
							,
											VALUE(CODPRODU
							,0)
							,
											TIPAPO
											FROM SEGUROS.V1ENDOSSO
											WHERE NUM_APOLICE = '{this.V1EDIA_NUMAPOL}'
											AND NRENDOS = '{this.V1EDIA_NRENDOS}'";

            return query;
        }
        public string V1ENDO_NUMAPOL { get; set; }
        public string V1ENDO_NRENDOS { get; set; }
        public string V1ENDO_FONTE { get; set; }
        public string V1ENDO_NRPROPOS { get; set; }
        public string V1ENDO_QTPARCEL { get; set; }
        public string V1ENDO_DTEMIS { get; set; }
        public string V1ENDO_ORGAO { get; set; }
        public string V1ENDO_RAMO { get; set; }
        public string V1ENDO_CORRECAO { get; set; }
        public string V1ENDO_CODUNIMO { get; set; }
        public string V1ENDO_CODCLIEN { get; set; }
        public string V1ENDO_OCORR_END { get; set; }
        public string V1ENDO_CODSUBES { get; set; }
        public string V1ENDO_CODPRODU { get; set; }
        public string V1ENDO_TIPAPO { get; set; }
        public string V1EDIA_NUMAPOL { get; set; }
        public string V1EDIA_NRENDOS { get; set; }

        public static R1100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1 Execute(R1100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1 r1100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1)
        {
            var ths = r1100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1ENDO_NUMAPOL = result[i++].Value?.ToString();
            dta.V1ENDO_NRENDOS = result[i++].Value?.ToString();
            dta.V1ENDO_FONTE = result[i++].Value?.ToString();
            dta.V1ENDO_NRPROPOS = result[i++].Value?.ToString();
            dta.V1ENDO_QTPARCEL = result[i++].Value?.ToString();
            dta.V1ENDO_DTEMIS = result[i++].Value?.ToString();
            dta.V1ENDO_ORGAO = result[i++].Value?.ToString();
            dta.V1ENDO_RAMO = result[i++].Value?.ToString();
            dta.V1ENDO_CORRECAO = result[i++].Value?.ToString();
            dta.V1ENDO_CODUNIMO = result[i++].Value?.ToString();
            dta.V1ENDO_CODCLIEN = result[i++].Value?.ToString();
            dta.V1ENDO_OCORR_END = result[i++].Value?.ToString();
            dta.V1ENDO_CODSUBES = result[i++].Value?.ToString();
            dta.V1ENDO_CODPRODU = result[i++].Value?.ToString();
            dta.V1ENDO_TIPAPO = result[i++].Value?.ToString();
            return dta;
        }

    }
}