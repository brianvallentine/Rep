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
    public class M_1100_SELECT_ENDOSSOS_DB_SELECT_2_Query1 : QueryBasis<M_1100_SELECT_ENDOSSOS_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT OCORR_HISTORICO
            INTO :PARCELAS-OCORR-HISTORICO
            FROM SEGUROS.PARCELAS
            WHERE NUM_APOLICE =
            :HISCONPA-NUM-APOLICE
            AND NUM_ENDOSSO =
            :HISCONPA-NUM-ENDOSSO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT OCORR_HISTORICO
											FROM SEGUROS.PARCELAS
											WHERE NUM_APOLICE =
											'{this.HISCONPA_NUM_APOLICE}'
											AND NUM_ENDOSSO =
											'{this.HISCONPA_NUM_ENDOSSO}'";

            return query;
        }
        public string PARCELAS_OCORR_HISTORICO { get; set; }
        public string HISCONPA_NUM_APOLICE { get; set; }
        public string HISCONPA_NUM_ENDOSSO { get; set; }

        public static M_1100_SELECT_ENDOSSOS_DB_SELECT_2_Query1 Execute(M_1100_SELECT_ENDOSSOS_DB_SELECT_2_Query1 m_1100_SELECT_ENDOSSOS_DB_SELECT_2_Query1)
        {
            var ths = m_1100_SELECT_ENDOSSOS_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_1100_SELECT_ENDOSSOS_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_1100_SELECT_ENDOSSOS_DB_SELECT_2_Query1();
            var i = 0;
            dta.PARCELAS_OCORR_HISTORICO = result[i++].Value?.ToString();
            return dta;
        }

    }
}