using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI6032B
{
    public class R0075_00_LE_V0BILHETE_DB_SELECT_1_Query1 : QueryBasis<R0075_00_LE_V0BILHETE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUMBIL,
            CODCLIEN,
            NUM_MATRICULA,
            NUM_APOLICE,
            COD_AGENCIA_DEB,
            OPERACAO_CONTA_DEB,
            NUM_CONTA_DEB,
            DIG_CONTA_DEB
            INTO :V1BILH-NUMBIL,
            :V1BILH-COD-CLIENTE,
            :V1BILH-MATR-IND,
            :V1BILH-NUM-APOL,
            :V1BILH-AGENCIA-DEB,
            :V1BILH-OPERACAO-DEB,
            :V1BILH-CONTA-DEB,
            :V1BILH-DIGITO-DEB
            FROM SEGUROS.V0BILHETE
            WHERE NUMBIL = :V1BILH-NUMBIL
            AND SITUACAO IN ( '8' , '9' )
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUMBIL
							,
											CODCLIEN
							,
											NUM_MATRICULA
							,
											NUM_APOLICE
							,
											COD_AGENCIA_DEB
							,
											OPERACAO_CONTA_DEB
							,
											NUM_CONTA_DEB
							,
											DIG_CONTA_DEB
											FROM SEGUROS.V0BILHETE
											WHERE NUMBIL = '{this.V1BILH_NUMBIL}'
											AND SITUACAO IN ( '8' 
							, '9' )";

            return query;
        }
        public string V1BILH_NUMBIL { get; set; }
        public string V1BILH_COD_CLIENTE { get; set; }
        public string V1BILH_MATR_IND { get; set; }
        public string V1BILH_NUM_APOL { get; set; }
        public string V1BILH_AGENCIA_DEB { get; set; }
        public string V1BILH_OPERACAO_DEB { get; set; }
        public string V1BILH_CONTA_DEB { get; set; }
        public string V1BILH_DIGITO_DEB { get; set; }

        public static R0075_00_LE_V0BILHETE_DB_SELECT_1_Query1 Execute(R0075_00_LE_V0BILHETE_DB_SELECT_1_Query1 r0075_00_LE_V0BILHETE_DB_SELECT_1_Query1)
        {
            var ths = r0075_00_LE_V0BILHETE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0075_00_LE_V0BILHETE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0075_00_LE_V0BILHETE_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1BILH_NUMBIL = result[i++].Value?.ToString();
            dta.V1BILH_COD_CLIENTE = result[i++].Value?.ToString();
            dta.V1BILH_MATR_IND = result[i++].Value?.ToString();
            dta.V1BILH_NUM_APOL = result[i++].Value?.ToString();
            dta.V1BILH_AGENCIA_DEB = result[i++].Value?.ToString();
            dta.V1BILH_OPERACAO_DEB = result[i++].Value?.ToString();
            dta.V1BILH_CONTA_DEB = result[i++].Value?.ToString();
            dta.V1BILH_DIGITO_DEB = result[i++].Value?.ToString();
            return dta;
        }

    }
}