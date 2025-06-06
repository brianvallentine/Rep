using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0910S
{
    public class R1100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1 : QueryBasis<R1100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            ORGAO,
            RAMO,
            FONTE,
            NRPROPOS,
            COD_MOEDA_PRM,
            COD_MOEDA_IMP,
            TIPO_ENDOSSO ,
            TIPAPO ,
            CODPRODU
            INTO :V1ENDO-ORGAO,
            :V1ENDO-RAMO,
            :V1ENDO-FONTE,
            :V1ENDO-NRPROPOS,
            :V1ENDO-MOEDA-PRM,
            :V1ENDO-MOEDA-IMP,
            :V1ENDO-TIPO-ENDO,
            :V1ENDO-TIPAPO ,
            :V1ENDO-CODPRODU:VIND-CODPRODU
            FROM SEGUROS.V1ENDOSSO
            WHERE NUM_APOLICE = :WHOST-NUM-APOL
            AND NRENDOS = :WHOST-NRENDOS
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											ORGAO
							,
											RAMO
							,
											FONTE
							,
											NRPROPOS
							,
											COD_MOEDA_PRM
							,
											COD_MOEDA_IMP
							,
											TIPO_ENDOSSO 
							,
											TIPAPO 
							,
											CODPRODU
											FROM SEGUROS.V1ENDOSSO
											WHERE NUM_APOLICE = '{this.WHOST_NUM_APOL}'
											AND NRENDOS = '{this.WHOST_NRENDOS}'";

            return query;
        }
        public string V1ENDO_ORGAO { get; set; }
        public string V1ENDO_RAMO { get; set; }
        public string V1ENDO_FONTE { get; set; }
        public string V1ENDO_NRPROPOS { get; set; }
        public string V1ENDO_MOEDA_PRM { get; set; }
        public string V1ENDO_MOEDA_IMP { get; set; }
        public string V1ENDO_TIPO_ENDO { get; set; }
        public string V1ENDO_TIPAPO { get; set; }
        public string V1ENDO_CODPRODU { get; set; }
        public string VIND_CODPRODU { get; set; }
        public string WHOST_NUM_APOL { get; set; }
        public string WHOST_NRENDOS { get; set; }

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
            dta.V1ENDO_ORGAO = result[i++].Value?.ToString();
            dta.V1ENDO_RAMO = result[i++].Value?.ToString();
            dta.V1ENDO_FONTE = result[i++].Value?.ToString();
            dta.V1ENDO_NRPROPOS = result[i++].Value?.ToString();
            dta.V1ENDO_MOEDA_PRM = result[i++].Value?.ToString();
            dta.V1ENDO_MOEDA_IMP = result[i++].Value?.ToString();
            dta.V1ENDO_TIPO_ENDO = result[i++].Value?.ToString();
            dta.V1ENDO_TIPAPO = result[i++].Value?.ToString();
            dta.V1ENDO_CODPRODU = result[i++].Value?.ToString();
            dta.VIND_CODPRODU = string.IsNullOrWhiteSpace(dta.V1ENDO_CODPRODU) ? "-1" : "0";
            return dta;
        }

    }
}