using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0005B
{
    public class R110_ROTINA_CRITICA_DADOS_DB_SELECT_7_Query1 : QueryBasis<R110_ROTINA_CRITICA_DADOS_DB_SELECT_7_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT L.COD_LOT_CEF
            ,L.COD_LOT_FENAL
            ,L.COD_CLIENTE
            ,L.NUM_APOLICE
            ,L.DTINIVIG
            ,L.DTTERVIG
            ,C.NOME_RAZAO
            INTO :LOTERI01-COD-LOT-CEF
            ,:LOTERI01-COD-LOT-FENAL
            ,:LOTERI01-COD-CLIENTE
            ,:LOTERI01-NUM-APOLICE
            ,:LOTERI01-DTINIVIG
            ,:LOTERI01-DTTERVIG
            ,:CLIENTES-NOME-RAZAO
            FROM SEGUROS.LOTERICO01 L
            ,SEGUROS.CLIENTES C
            WHERE L.COD_LOT_CEF = :LOTERI01-COD-LOT-CEF
            AND L.COD_LOT_FENAL = :LOTERI01-COD-LOT-FENAL
            AND L.NUM_APOLICE = :LOTERI01-NUM-APOLICE
            AND C.COD_CLIENTE = L.COD_CLIENTE
            AND L.DTINIVIG =
            ( SELECT MAX(A.DTINIVIG)
            FROM SEGUROS.LOTERICO01 A
            WHERE A.COD_LOT_CEF = :LOTERI01-COD-LOT-CEF
            AND A.COD_LOT_FENAL = :LOTERI01-COD-LOT-FENAL
            AND A.NUM_APOLICE = :LOTERI01-NUM-APOLICE
            AND A.DTINIVIG <= :HOST-DATA-OCORRENCIA
            AND A.DTTERVIG >= :HOST-DATA-OCORRENCIA
            )
            AND L.DTINIVIG <= :HOST-DATA-OCORRENCIA
            AND L.DTTERVIG >= :HOST-DATA-OCORRENCIA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT L.COD_LOT_CEF
											,L.COD_LOT_FENAL
											,L.COD_CLIENTE
											,L.NUM_APOLICE
											,L.DTINIVIG
											,L.DTTERVIG
											,C.NOME_RAZAO
											FROM SEGUROS.LOTERICO01 L
											,SEGUROS.CLIENTES C
											WHERE L.COD_LOT_CEF = '{this.LOTERI01_COD_LOT_CEF}'
											AND L.COD_LOT_FENAL = '{this.LOTERI01_COD_LOT_FENAL}'
											AND L.NUM_APOLICE = '{this.LOTERI01_NUM_APOLICE}'
											AND C.COD_CLIENTE = L.COD_CLIENTE
											AND L.DTINIVIG =
											( SELECT MAX(A.DTINIVIG)
											FROM SEGUROS.LOTERICO01 A
											WHERE A.COD_LOT_CEF = '{this.LOTERI01_COD_LOT_CEF}'
											AND A.COD_LOT_FENAL = '{this.LOTERI01_COD_LOT_FENAL}'
											AND A.NUM_APOLICE = '{this.LOTERI01_NUM_APOLICE}'
											AND A.DTINIVIG <= '{this.HOST_DATA_OCORRENCIA}'
											AND A.DTTERVIG >= '{this.HOST_DATA_OCORRENCIA}'
											)
											AND L.DTINIVIG <= '{this.HOST_DATA_OCORRENCIA}'
											AND L.DTTERVIG >= '{this.HOST_DATA_OCORRENCIA}'";

            return query;
        }
        public string LOTERI01_COD_LOT_CEF { get; set; }
        public string LOTERI01_COD_LOT_FENAL { get; set; }
        public string LOTERI01_COD_CLIENTE { get; set; }
        public string LOTERI01_NUM_APOLICE { get; set; }
        public string LOTERI01_DTINIVIG { get; set; }
        public string LOTERI01_DTTERVIG { get; set; }
        public string CLIENTES_NOME_RAZAO { get; set; }
        public string HOST_DATA_OCORRENCIA { get; set; }

        public static R110_ROTINA_CRITICA_DADOS_DB_SELECT_7_Query1 Execute(R110_ROTINA_CRITICA_DADOS_DB_SELECT_7_Query1 r110_ROTINA_CRITICA_DADOS_DB_SELECT_7_Query1)
        {
            var ths = r110_ROTINA_CRITICA_DADOS_DB_SELECT_7_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R110_ROTINA_CRITICA_DADOS_DB_SELECT_7_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R110_ROTINA_CRITICA_DADOS_DB_SELECT_7_Query1();
            var i = 0;
            dta.LOTERI01_COD_LOT_CEF = result[i++].Value?.ToString();
            dta.LOTERI01_COD_LOT_FENAL = result[i++].Value?.ToString();
            dta.LOTERI01_COD_CLIENTE = result[i++].Value?.ToString();
            dta.LOTERI01_NUM_APOLICE = result[i++].Value?.ToString();
            dta.LOTERI01_DTINIVIG = result[i++].Value?.ToString();
            dta.LOTERI01_DTTERVIG = result[i++].Value?.ToString();
            dta.CLIENTES_NOME_RAZAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}