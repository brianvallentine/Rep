using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0155B
{
    public class R2150_00_SELECT_V0PARCAVISO_DB_SELECT_1_Query1 : QueryBasis<R2150_00_SELECT_V0PARCAVISO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SUM(C.VAL_OPERACAO)
            INTO :SINISHIS-VAL-OPERACAO:VIND-ORIGEM
            FROM SEGUROS.SI_RESSARC_PARCELA A ,
            SEGUROS.SI_PARCELA_AVISO B ,
            SEGUROS.SINISTRO_HISTORICO C
            WHERE B.BCO_AVISO =
            :SI127-BCO-AVISO
            AND B.AGE_AVISO =
            :SI127-AGE-AVISO
            AND B.NUM_AVISO_CREDITO =
            :SI127-NUM-AVISO-CREDITO
            AND C.COD_OPERACAO = 4100
            AND C.NUM_APOL_SINISTRO = A.NUM_APOL_SINISTRO
            AND C.OCORR_HISTORICO = A.OCORR_HISTORICO
            AND C.COD_OPERACAO = A.COD_OPERACAO
            AND C.NUM_APOL_SINISTRO = B.NUM_APOL_SINISTRO
            AND C.OCORR_HISTORICO = B.OCORR_HISTORICO
            AND C.COD_OPERACAO = B.COD_OPERACAO_SINI
            AND A.NUM_APOL_SINISTRO = B.NUM_APOL_SINISTRO
            AND A.OCORR_HISTORICO = B.OCORR_HISTORICO
            AND A.COD_OPERACAO = B.COD_OPERACAO_SINI
            AND A.NUM_RESSARC = B.NUM_RESSARC
            AND A.SEQ_RESSARC = B.SEQ_RESSARC
            AND A.NUM_PARCELA = B.NUM_PARCELA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SUM(C.VAL_OPERACAO)
											FROM SEGUROS.SI_RESSARC_PARCELA A 
							,
											SEGUROS.SI_PARCELA_AVISO B 
							,
											SEGUROS.SINISTRO_HISTORICO C
											WHERE B.BCO_AVISO =
											'{this.SI127_BCO_AVISO}'
											AND B.AGE_AVISO =
											'{this.SI127_AGE_AVISO}'
											AND B.NUM_AVISO_CREDITO =
											'{this.SI127_NUM_AVISO_CREDITO}'
											AND C.COD_OPERACAO = 4100
											AND C.NUM_APOL_SINISTRO = A.NUM_APOL_SINISTRO
											AND C.OCORR_HISTORICO = A.OCORR_HISTORICO
											AND C.COD_OPERACAO = A.COD_OPERACAO
											AND C.NUM_APOL_SINISTRO = B.NUM_APOL_SINISTRO
											AND C.OCORR_HISTORICO = B.OCORR_HISTORICO
											AND C.COD_OPERACAO = B.COD_OPERACAO_SINI
											AND A.NUM_APOL_SINISTRO = B.NUM_APOL_SINISTRO
											AND A.OCORR_HISTORICO = B.OCORR_HISTORICO
											AND A.COD_OPERACAO = B.COD_OPERACAO_SINI
											AND A.NUM_RESSARC = B.NUM_RESSARC
											AND A.SEQ_RESSARC = B.SEQ_RESSARC
											AND A.NUM_PARCELA = B.NUM_PARCELA";

            return query;
        }
        public string SINISHIS_VAL_OPERACAO { get; set; }
        public string VIND_ORIGEM { get; set; }
        public string SI127_NUM_AVISO_CREDITO { get; set; }
        public string SI127_BCO_AVISO { get; set; }
        public string SI127_AGE_AVISO { get; set; }

        public static R2150_00_SELECT_V0PARCAVISO_DB_SELECT_1_Query1 Execute(R2150_00_SELECT_V0PARCAVISO_DB_SELECT_1_Query1 r2150_00_SELECT_V0PARCAVISO_DB_SELECT_1_Query1)
        {
            var ths = r2150_00_SELECT_V0PARCAVISO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2150_00_SELECT_V0PARCAVISO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2150_00_SELECT_V0PARCAVISO_DB_SELECT_1_Query1();
            var i = 0;
            dta.SINISHIS_VAL_OPERACAO = result[i++].Value?.ToString();
            dta.VIND_ORIGEM = string.IsNullOrWhiteSpace(dta.SINISHIS_VAL_OPERACAO) ? "-1" : "0";
            return dta;
        }

    }
}