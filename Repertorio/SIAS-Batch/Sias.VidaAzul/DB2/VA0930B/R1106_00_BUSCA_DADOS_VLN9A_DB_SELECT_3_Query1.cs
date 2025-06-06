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
    public class R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_3_Query1 : QueryBasis<R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_3_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT OPCAO_PAGAMENTO
            INTO :OPCPAGVI-OPCAO-PAGAMENTO
            FROM SEGUROS.OPCAO_PAG_VIDAZUL
            WHERE NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO
            AND DATA_TERVIGENCIA <= :RELATORI-DATA-SOLICITACAO
            ORDER BY DATA_TERVIGENCIA DESC
            FETCH FIRST 1 ROW ONLY
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT OPCAO_PAGAMENTO
											FROM SEGUROS.OPCAO_PAG_VIDAZUL
											WHERE NUM_CERTIFICADO = '{this.RELATORI_NUM_CERTIFICADO}'
											AND DATA_TERVIGENCIA <= '{this.RELATORI_DATA_SOLICITACAO}'
											ORDER BY DATA_TERVIGENCIA DESC
											FETCH FIRST 1 ROW ONLY
											WITH UR";

            return query;
        }
        public string OPCPAGVI_OPCAO_PAGAMENTO { get; set; }
        public string RELATORI_DATA_SOLICITACAO { get; set; }
        public string RELATORI_NUM_CERTIFICADO { get; set; }

        public static R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_3_Query1 Execute(R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_3_Query1 r1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_3_Query1)
        {
            var ths = r1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_3_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_3_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_3_Query1();
            var i = 0;
            dta.OPCPAGVI_OPCAO_PAGAMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}