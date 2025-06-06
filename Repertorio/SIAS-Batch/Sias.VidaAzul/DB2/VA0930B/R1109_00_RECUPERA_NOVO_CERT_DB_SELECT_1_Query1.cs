using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0930B
{
    public class R1109_00_RECUPERA_NOVO_CERT_DB_SELECT_1_Query1 : QueryBasis<R1109_00_RECUPERA_NOVO_CERT_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_CERTIFICADO
            INTO :PROPOVA-NUM-CERTIFICADO
            FROM SEGUROS.PROPOSTAS_VA
            WHERE NRCERTIFANT = :RELATORI-NUM-CERTIFICADO
            AND SIT_REGISTRO NOT IN ( '2' , '4' )
            AND DATA_QUITACAO = :RELATORI-DATA-SOLICITACAO
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT NUM_CERTIFICADO
											FROM SEGUROS.PROPOSTAS_VA
											WHERE NRCERTIFANT = '{this.RELATORI_NUM_CERTIFICADO}'
											AND SIT_REGISTRO NOT IN ( '2' 
							, '4' )
											AND DATA_QUITACAO = '{this.RELATORI_DATA_SOLICITACAO}'
											WITH UR";

            return query;
        }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }
        public string RELATORI_DATA_SOLICITACAO { get; set; }
        public string RELATORI_NUM_CERTIFICADO { get; set; }

        public static R1109_00_RECUPERA_NOVO_CERT_DB_SELECT_1_Query1 Execute(R1109_00_RECUPERA_NOVO_CERT_DB_SELECT_1_Query1 r1109_00_RECUPERA_NOVO_CERT_DB_SELECT_1_Query1)
        {
            var ths = r1109_00_RECUPERA_NOVO_CERT_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1109_00_RECUPERA_NOVO_CERT_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1109_00_RECUPERA_NOVO_CERT_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPOVA_NUM_CERTIFICADO = result[i++].Value?.ToString();
            return dta;
        }

    }
}