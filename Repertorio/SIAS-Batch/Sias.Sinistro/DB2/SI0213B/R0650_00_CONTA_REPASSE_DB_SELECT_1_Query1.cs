using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0213B
{
    public class R0650_00_CONTA_REPASSE_DB_SELECT_1_Query1 : QueryBasis<R0650_00_CONTA_REPASSE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(COUNT(*), 0)
            INTO :HOST-COUNT-REPASSE
            FROM SEGUROS.SINISTRO_HISTORICO H,
            SEGUROS.SI_RESSARC_PARCELA P,
            SEGUROS.FORNECEDORES F
            WHERE H.COD_OPERACAO = :SINISHIS-COD-OPERACAO
            AND F.TIPO_REGISTRO = '4'
            AND H.NUM_APOL_SINISTRO = P.NUM_APOL_SINISTRO
            AND H.OCORR_HISTORICO = P.OCORR_HISTORICO
            AND H.COD_OPERACAO = P.COD_OPERACAO
            AND H.DATA_MOVIMENTO >= :HOST-DATA-SISTEMA-MENOS-60DIAS
            AND H.COD_PREST_SERVICO = F.COD_FORNECEDOR
            AND NOT EXISTS
            (SELECT W.NUM_APOL_SINISTRO
            FROM SEGUROS.SINISTRO_HISTORICO W
            WHERE W.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO
            AND W.OCORR_HISTORICO = H.OCORR_HISTORICO
            AND W.COD_OPERACAO =
            :HOST-COD-OPERACAO-PAG)
            AND EXISTS
            (SELECT Z.NUM_APOL_SINISTRO
            FROM SEGUROS.SINISTRO_HISTORICO Z
            WHERE Z.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO
            AND Z.OCORR_HISTORICO = H.OCORR_HISTORICO
            AND Z.COD_OPERACAO = 4100)
            AND NOT EXISTS
            (SELECT T.NUM_APOL_SINISTRO
            FROM SEGUROS.SINISTRO_HISTORICO T
            WHERE T.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO
            AND T.OCORR_HISTORICO = H.OCORR_HISTORICO
            AND T.COD_OPERACAO = 4120)
            AND NOT EXISTS
            (SELECT Y.NUM_APOL_SINISTRO
            FROM SEGUROS.SINISTRO_LANCLOTE1 Y,
            SEGUROS.SINISTRO_CAPALOTE1 V
            WHERE Y.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO
            AND Y.OCORR_HISTORICO = H.OCORR_HISTORICO
            AND Y.COD_OPERACAO = H.COD_OPERACAO
            AND V.COD_FONTE = Y.COD_FONTE
            AND V.NUM_LOTE = Y.NUM_LOTE
            AND V.SITUACAO_LOTE <> 'C' )
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(COUNT(*)
							, 0)
											FROM SEGUROS.SINISTRO_HISTORICO H
							,
											SEGUROS.SI_RESSARC_PARCELA P
							,
											SEGUROS.FORNECEDORES F
											WHERE H.COD_OPERACAO = '{this.SINISHIS_COD_OPERACAO}'
											AND F.TIPO_REGISTRO = '4'
											AND H.NUM_APOL_SINISTRO = P.NUM_APOL_SINISTRO
											AND H.OCORR_HISTORICO = P.OCORR_HISTORICO
											AND H.COD_OPERACAO = P.COD_OPERACAO
											AND H.DATA_MOVIMENTO >= '{this.HOST_DATA_SISTEMA_MENOS_60DIAS}'
											AND H.COD_PREST_SERVICO = F.COD_FORNECEDOR
											AND NOT EXISTS
											(SELECT W.NUM_APOL_SINISTRO
											FROM SEGUROS.SINISTRO_HISTORICO W
											WHERE W.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO
											AND W.OCORR_HISTORICO = H.OCORR_HISTORICO
											AND W.COD_OPERACAO =
											'{this.HOST_COD_OPERACAO_PAG}')
											AND EXISTS
											(SELECT Z.NUM_APOL_SINISTRO
											FROM SEGUROS.SINISTRO_HISTORICO Z
											WHERE Z.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO
											AND Z.OCORR_HISTORICO = H.OCORR_HISTORICO
											AND Z.COD_OPERACAO = 4100)
											AND NOT EXISTS
											(SELECT T.NUM_APOL_SINISTRO
											FROM SEGUROS.SINISTRO_HISTORICO T
											WHERE T.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO
											AND T.OCORR_HISTORICO = H.OCORR_HISTORICO
											AND T.COD_OPERACAO = 4120)
											AND NOT EXISTS
											(SELECT Y.NUM_APOL_SINISTRO
											FROM SEGUROS.SINISTRO_LANCLOTE1 Y
							,
											SEGUROS.SINISTRO_CAPALOTE1 V
											WHERE Y.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO
											AND Y.OCORR_HISTORICO = H.OCORR_HISTORICO
											AND Y.COD_OPERACAO = H.COD_OPERACAO
											AND V.COD_FONTE = Y.COD_FONTE
											AND V.NUM_LOTE = Y.NUM_LOTE
											AND V.SITUACAO_LOTE <> 'C' )";

            return query;
        }
        public string HOST_COUNT_REPASSE { get; set; }
        public string HOST_DATA_SISTEMA_MENOS_60DIAS { get; set; }
        public string SINISHIS_COD_OPERACAO { get; set; }
        public string HOST_COD_OPERACAO_PAG { get; set; }

        public static R0650_00_CONTA_REPASSE_DB_SELECT_1_Query1 Execute(R0650_00_CONTA_REPASSE_DB_SELECT_1_Query1 r0650_00_CONTA_REPASSE_DB_SELECT_1_Query1)
        {
            var ths = r0650_00_CONTA_REPASSE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0650_00_CONTA_REPASSE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0650_00_CONTA_REPASSE_DB_SELECT_1_Query1();
            var i = 0;
            dta.HOST_COUNT_REPASSE = result[i++].Value?.ToString();
            return dta;
        }

    }
}