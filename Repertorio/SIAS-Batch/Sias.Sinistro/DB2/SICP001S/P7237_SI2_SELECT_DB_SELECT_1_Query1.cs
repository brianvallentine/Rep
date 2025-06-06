using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SICP001S
{
    public class P7237_SI2_SELECT_DB_SELECT_1_Query1 : QueryBasis<P7237_SI2_SELECT_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            VALUE(NUM_ID_ENVIO,
            0)
            ,VALUE(SEQ_ID_ENVIO_HIST,
            0)
            ,STA_ENVIO_MOVIMENTO
            INTO
            :SI237-NUM-ID-ENVIO
            ,:SI237-SEQ-ID-ENVIO-HIST
            ,:SI237-STA-ENVIO-MOVIMENTO
            FROM SEGUROS.SI_MOVTO_PGTO_COB
            WHERE NUM_SINISTRO = :SI237-NUM-SINISTRO
            AND COD_OPERACAO = :SI237-COD-OPERACAO
            AND OCORR_HISTORICO = :SI237-OCORR-HISTORICO
            AND IDE_SISTEMA = 'SI'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											VALUE(NUM_ID_ENVIO
							,
											0)
											,VALUE(SEQ_ID_ENVIO_HIST
							,
											0)
											,STA_ENVIO_MOVIMENTO
											FROM SEGUROS.SI_MOVTO_PGTO_COB
											WHERE NUM_SINISTRO = '{this.SI237_NUM_SINISTRO}'
											AND COD_OPERACAO = '{this.SI237_COD_OPERACAO}'
											AND OCORR_HISTORICO = '{this.SI237_OCORR_HISTORICO}'
											AND IDE_SISTEMA = 'SI'
											WITH UR";

            return query;
        }
        public string SI237_NUM_ID_ENVIO { get; set; }
        public string SI237_SEQ_ID_ENVIO_HIST { get; set; }
        public string SI237_STA_ENVIO_MOVIMENTO { get; set; }
        public string SI237_OCORR_HISTORICO { get; set; }
        public string SI237_NUM_SINISTRO { get; set; }
        public string SI237_COD_OPERACAO { get; set; }

        public static P7237_SI2_SELECT_DB_SELECT_1_Query1 Execute(P7237_SI2_SELECT_DB_SELECT_1_Query1 p7237_SI2_SELECT_DB_SELECT_1_Query1)
        {
            var ths = p7237_SI2_SELECT_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override P7237_SI2_SELECT_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new P7237_SI2_SELECT_DB_SELECT_1_Query1();
            var i = 0;
            dta.SI237_NUM_ID_ENVIO = result[i++].Value?.ToString();
            dta.SI237_SEQ_ID_ENVIO_HIST = result[i++].Value?.ToString();
            dta.SI237_STA_ENVIO_MOVIMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}