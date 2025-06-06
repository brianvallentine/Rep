using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0110B
{
    public class P22310_00_SELECT_GE381_DB_SELECT_1_Query1 : QueryBasis<P22310_00_SELECT_GE381_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(COD_BCO, 0)
            ,VALUE(COD_AGENCIA, ' ' )
            ,VALUE(COD_AGENCIA_DV, ' ' )
            ,VALUE(COD_OPERACAO, 0)
            ,VALUE(NUM_CONTA, 0)
            ,VALUE(NUM_CONTA_DV1, ' ' )
            INTO :GE381-COD-BCO
            ,:GE381-COD-AGENCIA
            ,:GE381-COD-AGENCIA-DV
            ,:GE381-COD-OPERACAO
            ,:GE381-NUM-CONTA
            ,:GE381-NUM-CONTA-DV1
            FROM SEGUROS.GE_CLI_DADOS_FINANC
            WHERE COD_CLIENTE = :GE381-COD-CLIENTE
            AND COD_TIPO_CONTA = ' '
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(COD_BCO
							, 0)
											,VALUE(COD_AGENCIA
							, ' ' )
											,VALUE(COD_AGENCIA_DV
							, ' ' )
											,VALUE(COD_OPERACAO
							, 0)
											,VALUE(NUM_CONTA
							, 0)
											,VALUE(NUM_CONTA_DV1
							, ' ' )
											FROM SEGUROS.GE_CLI_DADOS_FINANC
											WHERE COD_CLIENTE = '{this.GE381_COD_CLIENTE}'
											AND COD_TIPO_CONTA = ' '
											WITH UR";

            return query;
        }
        public string GE381_COD_BCO { get; set; }
        public string GE381_COD_AGENCIA { get; set; }
        public string GE381_COD_AGENCIA_DV { get; set; }
        public string GE381_COD_OPERACAO { get; set; }
        public string GE381_NUM_CONTA { get; set; }
        public string GE381_NUM_CONTA_DV1 { get; set; }
        public string GE381_COD_CLIENTE { get; set; }

        public static P22310_00_SELECT_GE381_DB_SELECT_1_Query1 Execute(P22310_00_SELECT_GE381_DB_SELECT_1_Query1 p22310_00_SELECT_GE381_DB_SELECT_1_Query1)
        {
            var ths = p22310_00_SELECT_GE381_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override P22310_00_SELECT_GE381_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new P22310_00_SELECT_GE381_DB_SELECT_1_Query1();
            var i = 0;
            dta.GE381_COD_BCO = result[i++].Value?.ToString();
            dta.GE381_COD_AGENCIA = result[i++].Value?.ToString();
            dta.GE381_COD_AGENCIA_DV = result[i++].Value?.ToString();
            dta.GE381_COD_OPERACAO = result[i++].Value?.ToString();
            dta.GE381_NUM_CONTA = result[i++].Value?.ToString();
            dta.GE381_NUM_CONTA_DV1 = result[i++].Value?.ToString();
            return dta;
        }

    }
}