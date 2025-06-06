using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0003B
{
    public class R2100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1 : QueryBasis<R2100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            ORGAO ,
            RAMO ,
            DTEMIS ,
            DTINIVIG ,
            DTTERVIG ,
            COD_MOEDA_IMP ,
            COD_MOEDA_PRM ,
            BCORCAP ,
            AGERCAP ,
            DACRCAP ,
            BCOCOBR ,
            AGECOBR ,
            DACCOBR ,
            CORRECAO ,
            CODPRODU ,
            FONTE ,
            NRRCAP ,
            QTPARCEL
            INTO
            :V1ENDO-ORGAO ,
            :V1ENDO-RAMO ,
            :V1ENDO-DTEMIS ,
            :V1ENDO-DTINIVIG ,
            :V1ENDO-DTTERVIG ,
            :V1ENDO-MOEDA-IMP ,
            :V1ENDO-MOEDA-PRM ,
            :V1ENDO-BCORCAP ,
            :V1ENDO-AGERCAP ,
            :V1ENDO-DACRCAP ,
            :V1ENDO-BCOCOBR ,
            :V1ENDO-AGECOBR ,
            :V1ENDO-DACCOBR ,
            :V1ENDO-CORRECAO ,
            :V1ENDO-CODPRODU:VIND-CODPRODU,
            :V1ENDO-FONTE ,
            :V1ENDO-NRRCAP ,
            :V1ENDO-QTPARCEL
            FROM SEGUROS.V1ENDOSSO
            WHERE NUM_APOLICE = :V1PARC-NUM-APOL
            AND NRENDOS = :V1PARC-NRENDOS
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											ORGAO 
							,
											RAMO 
							,
											DTEMIS 
							,
											DTINIVIG 
							,
											DTTERVIG 
							,
											COD_MOEDA_IMP 
							,
											COD_MOEDA_PRM 
							,
											BCORCAP 
							,
											AGERCAP 
							,
											DACRCAP 
							,
											BCOCOBR 
							,
											AGECOBR 
							,
											DACCOBR 
							,
											CORRECAO 
							,
											CODPRODU 
							,
											FONTE 
							,
											NRRCAP 
							,
											QTPARCEL
											FROM SEGUROS.V1ENDOSSO
											WHERE NUM_APOLICE = '{this.V1PARC_NUM_APOL}'
											AND NRENDOS = '{this.V1PARC_NRENDOS}'
											WITH UR";

            return query;
        }
        public string V1ENDO_ORGAO { get; set; }
        public string V1ENDO_RAMO { get; set; }
        public string V1ENDO_DTEMIS { get; set; }
        public string V1ENDO_DTINIVIG { get; set; }
        public string V1ENDO_DTTERVIG { get; set; }
        public string V1ENDO_MOEDA_IMP { get; set; }
        public string V1ENDO_MOEDA_PRM { get; set; }
        public string V1ENDO_BCORCAP { get; set; }
        public string V1ENDO_AGERCAP { get; set; }
        public string V1ENDO_DACRCAP { get; set; }
        public string V1ENDO_BCOCOBR { get; set; }
        public string V1ENDO_AGECOBR { get; set; }
        public string V1ENDO_DACCOBR { get; set; }
        public string V1ENDO_CORRECAO { get; set; }
        public string V1ENDO_CODPRODU { get; set; }
        public string VIND_CODPRODU { get; set; }
        public string V1ENDO_FONTE { get; set; }
        public string V1ENDO_NRRCAP { get; set; }
        public string V1ENDO_QTPARCEL { get; set; }
        public string V1PARC_NUM_APOL { get; set; }
        public string V1PARC_NRENDOS { get; set; }

        public static R2100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1 Execute(R2100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1 r2100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1)
        {
            var ths = r2100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1ENDO_ORGAO = result[i++].Value?.ToString();
            dta.V1ENDO_RAMO = result[i++].Value?.ToString();
            dta.V1ENDO_DTEMIS = result[i++].Value?.ToString();
            dta.V1ENDO_DTINIVIG = result[i++].Value?.ToString();
            dta.V1ENDO_DTTERVIG = result[i++].Value?.ToString();
            dta.V1ENDO_MOEDA_IMP = result[i++].Value?.ToString();
            dta.V1ENDO_MOEDA_PRM = result[i++].Value?.ToString();
            dta.V1ENDO_BCORCAP = result[i++].Value?.ToString();
            dta.V1ENDO_AGERCAP = result[i++].Value?.ToString();
            dta.V1ENDO_DACRCAP = result[i++].Value?.ToString();
            dta.V1ENDO_BCOCOBR = result[i++].Value?.ToString();
            dta.V1ENDO_AGECOBR = result[i++].Value?.ToString();
            dta.V1ENDO_DACCOBR = result[i++].Value?.ToString();
            dta.V1ENDO_CORRECAO = result[i++].Value?.ToString();
            dta.V1ENDO_CODPRODU = result[i++].Value?.ToString();
            dta.VIND_CODPRODU = string.IsNullOrWhiteSpace(dta.V1ENDO_CODPRODU) ? "-1" : "0";
            dta.V1ENDO_FONTE = result[i++].Value?.ToString();
            dta.V1ENDO_NRRCAP = result[i++].Value?.ToString();
            dta.V1ENDO_QTPARCEL = result[i++].Value?.ToString();
            return dta;
        }

    }
}