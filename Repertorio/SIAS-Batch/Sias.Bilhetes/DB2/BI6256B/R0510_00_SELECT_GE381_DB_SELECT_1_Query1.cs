using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI6256B
{
    public class R0510_00_SELECT_GE381_DB_SELECT_1_Query1 : QueryBasis<R0510_00_SELECT_GE381_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.COD_FONTE
            ,A.NUM_PROPOSTA
            ,A.COD_PRODUTO
            ,B.COD_BCO
            ,B.COD_AGENCIA
            ,B.COD_AGENCIA_DV
            ,B.COD_OPERACAO
            ,B.NUM_CONTA
            ,B.NUM_CONTA_DV1
            INTO :PROPOSTA-COD-FONTE
            ,:PROPOSTA-NUM-PROPOSTA
            ,:ENDOSSOS-COD-PRODUTO
            ,:GE381-COD-BCO
            ,:GE381-COD-AGENCIA
            ,:GE381-COD-AGENCIA-DV:VIND-AGENCIA
            ,:GE381-COD-OPERACAO:VIND-OPE-CONTA
            ,:GE381-NUM-CONTA
            ,:GE381-NUM-CONTA-DV1
            FROM SEGUROS.PROPOSTAS A
            ,SEGUROS.GE_CLI_DADOS_FINANC B
            WHERE A.COD_FONTE = :PROPOSTA-COD-FONTE
            AND A.NUM_PROPOSTA = :PROPOSTA-NUM-PROPOSTA
            AND A.COD_CLIENTE = B.COD_CLIENTE
            AND B.COD_TIPO_CONTA = '1'
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.COD_FONTE
											,A.NUM_PROPOSTA
											,A.COD_PRODUTO
											,B.COD_BCO
											,B.COD_AGENCIA
											,B.COD_AGENCIA_DV
											,B.COD_OPERACAO
											,B.NUM_CONTA
											,B.NUM_CONTA_DV1
											FROM SEGUROS.PROPOSTAS A
											,SEGUROS.GE_CLI_DADOS_FINANC B
											WHERE A.COD_FONTE = '{this.PROPOSTA_COD_FONTE}'
											AND A.NUM_PROPOSTA = '{this.PROPOSTA_NUM_PROPOSTA}'
											AND A.COD_CLIENTE = B.COD_CLIENTE
											AND B.COD_TIPO_CONTA = '1'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string PROPOSTA_COD_FONTE { get; set; }
        public string PROPOSTA_NUM_PROPOSTA { get; set; }
        public string ENDOSSOS_COD_PRODUTO { get; set; }
        public string GE381_COD_BCO { get; set; }
        public string GE381_COD_AGENCIA { get; set; }
        public string GE381_COD_AGENCIA_DV { get; set; }
        public string VIND_AGENCIA { get; set; }
        public string GE381_COD_OPERACAO { get; set; }
        public string VIND_OPE_CONTA { get; set; }
        public string GE381_NUM_CONTA { get; set; }
        public string GE381_NUM_CONTA_DV1 { get; set; }

        public static R0510_00_SELECT_GE381_DB_SELECT_1_Query1 Execute(R0510_00_SELECT_GE381_DB_SELECT_1_Query1 r0510_00_SELECT_GE381_DB_SELECT_1_Query1)
        {
            var ths = r0510_00_SELECT_GE381_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0510_00_SELECT_GE381_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0510_00_SELECT_GE381_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPOSTA_COD_FONTE = result[i++].Value?.ToString();
            dta.PROPOSTA_NUM_PROPOSTA = result[i++].Value?.ToString();
            dta.ENDOSSOS_COD_PRODUTO = result[i++].Value?.ToString();
            dta.GE381_COD_BCO = result[i++].Value?.ToString();
            dta.GE381_COD_AGENCIA = result[i++].Value?.ToString();
            dta.GE381_COD_AGENCIA_DV = result[i++].Value?.ToString();
            dta.VIND_AGENCIA = string.IsNullOrWhiteSpace(dta.GE381_COD_AGENCIA_DV) ? "-1" : "0";
            dta.GE381_COD_OPERACAO = result[i++].Value?.ToString();
            dta.VIND_OPE_CONTA = string.IsNullOrWhiteSpace(dta.GE381_COD_OPERACAO) ? "-1" : "0";
            dta.GE381_NUM_CONTA = result[i++].Value?.ToString();
            dta.GE381_NUM_CONTA_DV1 = result[i++].Value?.ToString();
            return dta;
        }

    }
}