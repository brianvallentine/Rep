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
    public class R111_VERIFICA_PGTO_PREMIO_DB_SELECT_1_Query1 : QueryBasis<R111_VERIFICA_PGTO_PREMIO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COUNT(*)
            INTO :WS-QT-REG
            FROM SEGUROS.PARCELAS A
            ,SEGUROS.PARCELA_HISTORICO B
            WHERE A.NUM_APOLICE = :LOTERI01-NUM-APOLICE
            AND A.SIT_REGISTRO = '0'
            AND A.NUM_APOLICE = B.NUM_APOLICE
            AND A.NUM_ENDOSSO = B.NUM_ENDOSSO
            AND A.NUM_PARCELA = B.NUM_PARCELA
            AND B.OCORR_HISTORICO = 1
            AND B.DATA_VENCIMENTO < :SISTEMAS-DATA-MOV-ABERTO
            AND NOT EXISTS
            ( SELECT C.NUM_APOLICE
            FROM SEGUROS.MOVTO_DEBITOCC_CEF C
            WHERE C.NUM_APOLICE = A.NUM_APOLICE
            AND C.NUM_ENDOSSO = A.NUM_ENDOSSO
            AND C.NUM_PARCELA = A.NUM_PARCELA
            AND C.SITUACAO_COBRANCA IN ( ' ' , '1' , '2' )
            )
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT COUNT(*)
											FROM SEGUROS.PARCELAS A
											,SEGUROS.PARCELA_HISTORICO B
											WHERE A.NUM_APOLICE = '{this.LOTERI01_NUM_APOLICE}'
											AND A.SIT_REGISTRO = '0'
											AND A.NUM_APOLICE = B.NUM_APOLICE
											AND A.NUM_ENDOSSO = B.NUM_ENDOSSO
											AND A.NUM_PARCELA = B.NUM_PARCELA
											AND B.OCORR_HISTORICO = 1
											AND B.DATA_VENCIMENTO < '{this.SISTEMAS_DATA_MOV_ABERTO}'
											AND NOT EXISTS
											( SELECT C.NUM_APOLICE
											FROM SEGUROS.MOVTO_DEBITOCC_CEF C
											WHERE C.NUM_APOLICE = A.NUM_APOLICE
											AND C.NUM_ENDOSSO = A.NUM_ENDOSSO
											AND C.NUM_PARCELA = A.NUM_PARCELA
											AND C.SITUACAO_COBRANCA IN ( ' ' 
							, '1' 
							, '2' )
											)
											WITH UR";

            return query;
        }
        public string WS_QT_REG { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string LOTERI01_NUM_APOLICE { get; set; }

        public static R111_VERIFICA_PGTO_PREMIO_DB_SELECT_1_Query1 Execute(R111_VERIFICA_PGTO_PREMIO_DB_SELECT_1_Query1 r111_VERIFICA_PGTO_PREMIO_DB_SELECT_1_Query1)
        {
            var ths = r111_VERIFICA_PGTO_PREMIO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R111_VERIFICA_PGTO_PREMIO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R111_VERIFICA_PGTO_PREMIO_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_QT_REG = result[i++].Value?.ToString();
            return dta;
        }

    }
}