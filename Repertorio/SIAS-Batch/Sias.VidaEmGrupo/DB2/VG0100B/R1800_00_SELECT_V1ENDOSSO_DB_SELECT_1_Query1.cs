using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0100B
{
    public class R1800_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1 : QueryBasis<R1800_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            RAMO ,
            COD_MOEDA_IMP ,
            COD_MOEDA_PRM ,
            OCORR_ENDERECO ,
            CORRECAO ,
            CODPRODU
            INTO :V1ENDO-RAMO ,
            :V1ENDO-MOEDA-IMP ,
            :V1ENDO-MOEDA-PRM ,
            :V1ENDO-OCORR-END ,
            :V1ENDO-CORRECAO:V1ENDO-CORRECAO-I,
            :V1ENDO-CODPRODU
            FROM SEGUROS.V1ENDOSSO
            WHERE NUM_APOLICE = :W1SOLF-NUM-APOL
            AND NRENDOS = 0
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											RAMO 
							,
											COD_MOEDA_IMP 
							,
											COD_MOEDA_PRM 
							,
											OCORR_ENDERECO 
							,
											CORRECAO 
							,
											CODPRODU
											FROM SEGUROS.V1ENDOSSO
											WHERE NUM_APOLICE = '{this.W1SOLF_NUM_APOL}'
											AND NRENDOS = 0";

            return query;
        }
        public string V1ENDO_RAMO { get; set; }
        public string V1ENDO_MOEDA_IMP { get; set; }
        public string V1ENDO_MOEDA_PRM { get; set; }
        public string V1ENDO_OCORR_END { get; set; }
        public string V1ENDO_CORRECAO { get; set; }
        public string V1ENDO_CORRECAO_I { get; set; }
        public string V1ENDO_CODPRODU { get; set; }
        public string W1SOLF_NUM_APOL { get; set; }

        public static R1800_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1 Execute(R1800_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1 r1800_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1)
        {
            var ths = r1800_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1800_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1800_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1ENDO_RAMO = result[i++].Value?.ToString();
            dta.V1ENDO_MOEDA_IMP = result[i++].Value?.ToString();
            dta.V1ENDO_MOEDA_PRM = result[i++].Value?.ToString();
            dta.V1ENDO_OCORR_END = result[i++].Value?.ToString();
            dta.V1ENDO_CORRECAO = result[i++].Value?.ToString();
            dta.V1ENDO_CORRECAO_I = string.IsNullOrWhiteSpace(dta.V1ENDO_CORRECAO) ? "-1" : "0";
            dta.V1ENDO_CODPRODU = result[i++].Value?.ToString();
            return dta;
        }

    }
}