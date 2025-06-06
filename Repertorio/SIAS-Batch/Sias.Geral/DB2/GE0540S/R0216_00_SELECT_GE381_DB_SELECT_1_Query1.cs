using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0540S
{
    public class R0216_00_SELECT_GE381_DB_SELECT_1_Query1 : QueryBasis<R0216_00_SELECT_GE381_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_BCO
            ,COD_AGENCIA
            ,COD_AGENCIA_DV
            ,COD_OPERACAO
            ,NUM_CONTA
            ,NUM_CONTA_DV1
            INTO :GE381-COD-BCO
            ,:GE381-COD-AGENCIA
            ,:GE381-COD-AGENCIA-DV :VIND-COD-AGENCIA-DV
            ,:GE381-COD-OPERACAO :VIND-COD-OPERACAO
            ,:GE381-NUM-CONTA
            ,:GE381-NUM-CONTA-DV1
            FROM SEGUROS.GE_CLI_DADOS_FINANC
            WHERE COD_CLIENTE = :GE381-COD-CLIENTE
            AND COD_TIPO_CONTA = ' '
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_BCO
											,COD_AGENCIA
											,COD_AGENCIA_DV
											,COD_OPERACAO
											,NUM_CONTA
											,NUM_CONTA_DV1
											FROM SEGUROS.GE_CLI_DADOS_FINANC
											WHERE COD_CLIENTE = '{this.GE381_COD_CLIENTE}'
											AND COD_TIPO_CONTA = ' '
											WITH UR";

            return query;
        }
        public string GE381_COD_BCO { get; set; }
        public string GE381_COD_AGENCIA { get; set; }
        public string GE381_COD_AGENCIA_DV { get; set; }
        public string VIND_COD_AGENCIA_DV { get; set; }
        public string GE381_COD_OPERACAO { get; set; }
        public string VIND_COD_OPERACAO { get; set; }
        public string GE381_NUM_CONTA { get; set; }
        public string GE381_NUM_CONTA_DV1 { get; set; }
        public string GE381_COD_CLIENTE { get; set; }

        public static R0216_00_SELECT_GE381_DB_SELECT_1_Query1 Execute(R0216_00_SELECT_GE381_DB_SELECT_1_Query1 r0216_00_SELECT_GE381_DB_SELECT_1_Query1)
        {
            var ths = r0216_00_SELECT_GE381_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0216_00_SELECT_GE381_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0216_00_SELECT_GE381_DB_SELECT_1_Query1();
            var i = 0;
            dta.GE381_COD_BCO = result[i++].Value?.ToString();
            dta.GE381_COD_AGENCIA = result[i++].Value?.ToString();
            dta.GE381_COD_AGENCIA_DV = result[i++].Value?.ToString();
            dta.VIND_COD_AGENCIA_DV = string.IsNullOrWhiteSpace(dta.GE381_COD_AGENCIA_DV) ? "-1" : "0";
            dta.GE381_COD_OPERACAO = result[i++].Value?.ToString();
            dta.VIND_COD_OPERACAO = string.IsNullOrWhiteSpace(dta.GE381_COD_OPERACAO) ? "-1" : "0";
            dta.GE381_NUM_CONTA = result[i++].Value?.ToString();
            dta.GE381_NUM_CONTA_DV1 = result[i++].Value?.ToString();
            return dta;
        }

    }
}