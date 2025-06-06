using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0032B
{
    public class R0600_00_SELEC_V1BILHETE_DB_SELECT_1_Query1 : QueryBasis<R0600_00_SELEC_V1BILHETE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUMBIL ,
            COD_AGENCIA ,
            OPERACAO_CONTA ,
            NUM_CONTA ,
            DIG_CONTA ,
            COD_AGENCIA_DEB ,
            OPERACAO_CONTA_DEB,
            NUM_CONTA_DEB ,
            DIG_CONTA_DEB ,
            DTQITBCO ,
            VLRCAP ,
            NUM_APOL_ANTERIOR ,
            RAMO ,
            SITUACAO
            INTO :V1BILH-NUMBIL ,
            :V1BILH-AGENCIA ,
            :V1BILH-OPERACAO ,
            :V1BILH-NUMCTA ,
            :V1BILH-DIGCTA ,
            :V1BILH-AGENCIA-DEB ,
            :V1BILH-OPERACAO-DEB ,
            :V1BILH-NUMCTA-DEB ,
            :V1BILH-DIGCTA-DEB ,
            :V1BILH-DTQITBCO ,
            :V1BILH-VLRCAP ,
            :V1BILH-NUM-APOL-ANT ,
            :V1BILH-RAMO ,
            :V1BILH-SITUACAO
            FROM SEGUROS.V0BILHETE
            WHERE
            NUMBIL =:RELATORI-NUM-TITULO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUMBIL 
							,
											COD_AGENCIA 
							,
											OPERACAO_CONTA 
							,
											NUM_CONTA 
							,
											DIG_CONTA 
							,
											COD_AGENCIA_DEB 
							,
											OPERACAO_CONTA_DEB
							,
											NUM_CONTA_DEB 
							,
											DIG_CONTA_DEB 
							,
											DTQITBCO 
							,
											VLRCAP 
							,
											NUM_APOL_ANTERIOR 
							,
											RAMO 
							,
											SITUACAO
											FROM SEGUROS.V0BILHETE
											WHERE
											NUMBIL ='{this.RELATORI_NUM_TITULO}'";

            return query;
        }
        public string V1BILH_NUMBIL { get; set; }
        public string V1BILH_AGENCIA { get; set; }
        public string V1BILH_OPERACAO { get; set; }
        public string V1BILH_NUMCTA { get; set; }
        public string V1BILH_DIGCTA { get; set; }
        public string V1BILH_AGENCIA_DEB { get; set; }
        public string V1BILH_OPERACAO_DEB { get; set; }
        public string V1BILH_NUMCTA_DEB { get; set; }
        public string V1BILH_DIGCTA_DEB { get; set; }
        public string V1BILH_DTQITBCO { get; set; }
        public string V1BILH_VLRCAP { get; set; }
        public string V1BILH_NUM_APOL_ANT { get; set; }
        public string V1BILH_RAMO { get; set; }
        public string V1BILH_SITUACAO { get; set; }
        public string RELATORI_NUM_TITULO { get; set; }

        public static R0600_00_SELEC_V1BILHETE_DB_SELECT_1_Query1 Execute(R0600_00_SELEC_V1BILHETE_DB_SELECT_1_Query1 r0600_00_SELEC_V1BILHETE_DB_SELECT_1_Query1)
        {
            var ths = r0600_00_SELEC_V1BILHETE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0600_00_SELEC_V1BILHETE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0600_00_SELEC_V1BILHETE_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1BILH_NUMBIL = result[i++].Value?.ToString();
            dta.V1BILH_AGENCIA = result[i++].Value?.ToString();
            dta.V1BILH_OPERACAO = result[i++].Value?.ToString();
            dta.V1BILH_NUMCTA = result[i++].Value?.ToString();
            dta.V1BILH_DIGCTA = result[i++].Value?.ToString();
            dta.V1BILH_AGENCIA_DEB = result[i++].Value?.ToString();
            dta.V1BILH_OPERACAO_DEB = result[i++].Value?.ToString();
            dta.V1BILH_NUMCTA_DEB = result[i++].Value?.ToString();
            dta.V1BILH_DIGCTA_DEB = result[i++].Value?.ToString();
            dta.V1BILH_DTQITBCO = result[i++].Value?.ToString();
            dta.V1BILH_VLRCAP = result[i++].Value?.ToString();
            dta.V1BILH_NUM_APOL_ANT = result[i++].Value?.ToString();
            dta.V1BILH_RAMO = result[i++].Value?.ToString();
            dta.V1BILH_SITUACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}