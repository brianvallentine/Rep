using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI7401B
{
    public class R0330_00_SELECT_BILHETE_DB_SELECT_1_Query1 : QueryBasis<R0330_00_SELECT_BILHETE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.NUM_BILHETE
            ,A.NUM_APOLICE
            ,A.FONTE
            ,A.AGE_COBRANCA
            ,A.VAL_RCAP
            ,A.RAMO
            ,A.DATA_VENDA
            ,A.SITUACAO
            ,A.TIP_CANCELAMENTO
            ,A.DATA_CANCELAMENTO
            ,UCASE(C.NOME_RAZAO)
            ,C.CGCCPF
            INTO :BILHETE-NUM-BILHETE
            ,:BILHETE-NUM-APOLICE
            ,:BILHETE-FONTE
            ,:BILHETE-AGE-COBRANCA
            ,:BILHETE-VAL-RCAP
            ,:BILHETE-RAMO
            ,:BILHETE-DATA-VENDA
            ,:BILHETE-SITUACAO
            ,:BILHETE-TIP-CANCELAMENTO
            ,:BILHETE-DATA-CANCELAMENTO:VIND-NULL01
            ,:CLIENTES-NOME-RAZAO
            ,:CLIENTES-CGCCPF
            FROM SEGUROS.BILHETE A
            ,SEGUROS.CLIENTES C
            WHERE A.NUM_BILHETE = :RELATORI-NUM-TITULO
            AND C.COD_CLIENTE = A.COD_CLIENTE
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.NUM_BILHETE
											,A.NUM_APOLICE
											,A.FONTE
											,A.AGE_COBRANCA
											,A.VAL_RCAP
											,A.RAMO
											,A.DATA_VENDA
											,A.SITUACAO
											,A.TIP_CANCELAMENTO
											,A.DATA_CANCELAMENTO
											,UCASE(C.NOME_RAZAO)
											,C.CGCCPF
											FROM SEGUROS.BILHETE A
											,SEGUROS.CLIENTES C
											WHERE A.NUM_BILHETE = '{this.RELATORI_NUM_TITULO}'
											AND C.COD_CLIENTE = A.COD_CLIENTE
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string BILHETE_NUM_BILHETE { get; set; }
        public string BILHETE_NUM_APOLICE { get; set; }
        public string BILHETE_FONTE { get; set; }
        public string BILHETE_AGE_COBRANCA { get; set; }
        public string BILHETE_VAL_RCAP { get; set; }
        public string BILHETE_RAMO { get; set; }
        public string BILHETE_DATA_VENDA { get; set; }
        public string BILHETE_SITUACAO { get; set; }
        public string BILHETE_TIP_CANCELAMENTO { get; set; }
        public string BILHETE_DATA_CANCELAMENTO { get; set; }
        public string VIND_NULL01 { get; set; }
        public string CLIENTES_NOME_RAZAO { get; set; }
        public string CLIENTES_CGCCPF { get; set; }
        public string RELATORI_NUM_TITULO { get; set; }

        public static R0330_00_SELECT_BILHETE_DB_SELECT_1_Query1 Execute(R0330_00_SELECT_BILHETE_DB_SELECT_1_Query1 r0330_00_SELECT_BILHETE_DB_SELECT_1_Query1)
        {
            var ths = r0330_00_SELECT_BILHETE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0330_00_SELECT_BILHETE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0330_00_SELECT_BILHETE_DB_SELECT_1_Query1();
            var i = 0;
            dta.BILHETE_NUM_BILHETE = result[i++].Value?.ToString();
            dta.BILHETE_NUM_APOLICE = result[i++].Value?.ToString();
            dta.BILHETE_FONTE = result[i++].Value?.ToString();
            dta.BILHETE_AGE_COBRANCA = result[i++].Value?.ToString();
            dta.BILHETE_VAL_RCAP = result[i++].Value?.ToString();
            dta.BILHETE_RAMO = result[i++].Value?.ToString();
            dta.BILHETE_DATA_VENDA = result[i++].Value?.ToString();
            dta.BILHETE_SITUACAO = result[i++].Value?.ToString();
            dta.BILHETE_TIP_CANCELAMENTO = result[i++].Value?.ToString();
            dta.BILHETE_DATA_CANCELAMENTO = result[i++].Value?.ToString();
            dta.VIND_NULL01 = string.IsNullOrWhiteSpace(dta.BILHETE_DATA_CANCELAMENTO) ? "-1" : "0";
            dta.CLIENTES_NOME_RAZAO = result[i++].Value?.ToString();
            dta.CLIENTES_CGCCPF = result[i++].Value?.ToString();
            return dta;
        }

    }
}