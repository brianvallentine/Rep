using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0004B
{
    public class M_1100_SELECT_ENDOSSOS_DB_SELECT_3_Query1 : QueryBasis<M_1100_SELECT_ENDOSSOS_DB_SELECT_3_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(DATA_QUITACAO,
            DATE(:SISTEMAS-DATA-MOV-ABERTO))
            INTO :PARCEHIS-DATA-QUITACAO
            FROM SEGUROS.PARCELA_HISTORICO
            WHERE NUM_APOLICE =
            :HISCONPA-NUM-APOLICE
            AND NUM_ENDOSSO =
            :HISCONPA-NUM-ENDOSSO
            AND OCORR_HISTORICO =
            :PARCELAS-OCORR-HISTORICO
            AND COD_OPERACAO BETWEEN
            200 AND 299
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(DATA_QUITACAO
							,
											DATE('{this.SISTEMAS_DATA_MOV_ABERTO}'))
											FROM SEGUROS.PARCELA_HISTORICO
											WHERE NUM_APOLICE =
											'{this.HISCONPA_NUM_APOLICE}'
											AND NUM_ENDOSSO =
											'{this.HISCONPA_NUM_ENDOSSO}'
											AND OCORR_HISTORICO =
											'{this.PARCELAS_OCORR_HISTORICO}'
											AND COD_OPERACAO BETWEEN
											200 AND 299";

            return query;
        }
        public string PARCEHIS_DATA_QUITACAO { get; set; }
        public string PARCELAS_OCORR_HISTORICO { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string HISCONPA_NUM_APOLICE { get; set; }
        public string HISCONPA_NUM_ENDOSSO { get; set; }

        public static M_1100_SELECT_ENDOSSOS_DB_SELECT_3_Query1 Execute(M_1100_SELECT_ENDOSSOS_DB_SELECT_3_Query1 m_1100_SELECT_ENDOSSOS_DB_SELECT_3_Query1)
        {
            var ths = m_1100_SELECT_ENDOSSOS_DB_SELECT_3_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_1100_SELECT_ENDOSSOS_DB_SELECT_3_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_1100_SELECT_ENDOSSOS_DB_SELECT_3_Query1();
            var i = 0;
            dta.PARCEHIS_DATA_QUITACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}