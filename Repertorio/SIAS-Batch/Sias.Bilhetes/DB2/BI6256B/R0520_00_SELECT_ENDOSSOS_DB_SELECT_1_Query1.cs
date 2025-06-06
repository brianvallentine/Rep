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
    public class R0520_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 : QueryBasis<R0520_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT B.NUM_APOLICE
            ,B.NUM_ENDOSSO
            ,B.NUM_PARCELA
            ,B.SIT_REGISTRO
            ,C.COD_PRODUTO
            ,C.QTD_PARCELAS
            ,D.COD_BCO
            ,D.COD_AGENCIA
            ,D.COD_AGENCIA_DV
            ,D.COD_OPERACAO
            ,D.NUM_CONTA
            ,D.NUM_CONTA_DV1
            INTO :PARCELAS-NUM-APOLICE
            ,:PARCELAS-NUM-ENDOSSO
            ,:PARCELAS-NUM-PARCELA
            ,:PARCELAS-SIT-REGISTRO
            ,:ENDOSSOS-COD-PRODUTO
            ,:ENDOSSOS-QTD-PARCELAS
            ,:GE381-COD-BCO
            ,:GE381-COD-AGENCIA
            ,:GE381-COD-AGENCIA-DV:VIND-AGENCIA
            ,:GE381-COD-OPERACAO:VIND-OPE-CONTA
            ,:GE381-NUM-CONTA
            ,:GE381-NUM-CONTA-DV1
            FROM SEGUROS.APOLICES A
            ,SEGUROS.PARCELAS B
            ,SEGUROS.ENDOSSOS C
            ,SEGUROS.GE_CLI_DADOS_FINANC D
            WHERE A.NUM_APOLICE = :MOVDEBCE-NUM-APOLICE
            AND B.NUM_APOLICE = A.NUM_APOLICE
            AND B.NUM_ENDOSSO = :MOVDEBCE-NUM-ENDOSSO
            AND B.NUM_PARCELA = :MOVDEBCE-NUM-PARCELA
            AND B.SIT_REGISTRO = '0'
            AND C.NUM_APOLICE = B.NUM_APOLICE
            AND C.NUM_ENDOSSO = B.NUM_ENDOSSO
            AND D.COD_CLIENTE = A.COD_CLIENTE
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT B.NUM_APOLICE
											,B.NUM_ENDOSSO
											,B.NUM_PARCELA
											,B.SIT_REGISTRO
											,C.COD_PRODUTO
											,C.QTD_PARCELAS
											,D.COD_BCO
											,D.COD_AGENCIA
											,D.COD_AGENCIA_DV
											,D.COD_OPERACAO
											,D.NUM_CONTA
											,D.NUM_CONTA_DV1
											FROM SEGUROS.APOLICES A
											,SEGUROS.PARCELAS B
											,SEGUROS.ENDOSSOS C
											,SEGUROS.GE_CLI_DADOS_FINANC D
											WHERE A.NUM_APOLICE = '{this.MOVDEBCE_NUM_APOLICE}'
											AND B.NUM_APOLICE = A.NUM_APOLICE
											AND B.NUM_ENDOSSO = '{this.MOVDEBCE_NUM_ENDOSSO}'
											AND B.NUM_PARCELA = '{this.MOVDEBCE_NUM_PARCELA}'
											AND B.SIT_REGISTRO = '0'
											AND C.NUM_APOLICE = B.NUM_APOLICE
											AND C.NUM_ENDOSSO = B.NUM_ENDOSSO
											AND D.COD_CLIENTE = A.COD_CLIENTE
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string PARCELAS_NUM_APOLICE { get; set; }
        public string PARCELAS_NUM_ENDOSSO { get; set; }
        public string PARCELAS_NUM_PARCELA { get; set; }
        public string PARCELAS_SIT_REGISTRO { get; set; }
        public string ENDOSSOS_COD_PRODUTO { get; set; }
        public string ENDOSSOS_QTD_PARCELAS { get; set; }
        public string GE381_COD_BCO { get; set; }
        public string GE381_COD_AGENCIA { get; set; }
        public string GE381_COD_AGENCIA_DV { get; set; }
        public string VIND_AGENCIA { get; set; }
        public string GE381_COD_OPERACAO { get; set; }
        public string VIND_OPE_CONTA { get; set; }
        public string GE381_NUM_CONTA { get; set; }
        public string GE381_NUM_CONTA_DV1 { get; set; }
        public string MOVDEBCE_NUM_APOLICE { get; set; }
        public string MOVDEBCE_NUM_ENDOSSO { get; set; }
        public string MOVDEBCE_NUM_PARCELA { get; set; }

        public static R0520_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 Execute(R0520_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 r0520_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1)
        {
            var ths = r0520_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0520_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0520_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1();
            var i = 0;
            dta.PARCELAS_NUM_APOLICE = result[i++].Value?.ToString();
            dta.PARCELAS_NUM_ENDOSSO = result[i++].Value?.ToString();
            dta.PARCELAS_NUM_PARCELA = result[i++].Value?.ToString();
            dta.PARCELAS_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.ENDOSSOS_COD_PRODUTO = result[i++].Value?.ToString();
            dta.ENDOSSOS_QTD_PARCELAS = result[i++].Value?.ToString();
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