using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG9020S
{
    public class M_310_000_SELECT_V1HISTSEGVG_DB_SELECT_1_Query1 : QueryBasis<M_310_000_SELECT_V1HISTSEGVG_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT OCORR_HISTORICO
            INTO :HHOCORR-HISTORICO
            FROM SEGUROS.V1HISTSEGVG
            WHERE
            NUM_APOLICE = 109300000635
            AND NUM_ITEM = :SNUM-ITEM
            AND OCORR_HISTORICO = :MFAIXA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT OCORR_HISTORICO
											FROM SEGUROS.V1HISTSEGVG
											WHERE
											NUM_APOLICE = 109300000635
											AND NUM_ITEM = '{this.SNUM_ITEM}'
											AND OCORR_HISTORICO = '{this.MFAIXA}'";

            return query;
        }
        public string HHOCORR_HISTORICO { get; set; }
        public string SNUM_ITEM { get; set; }
        public string MFAIXA { get; set; }

        public static M_310_000_SELECT_V1HISTSEGVG_DB_SELECT_1_Query1 Execute(M_310_000_SELECT_V1HISTSEGVG_DB_SELECT_1_Query1 m_310_000_SELECT_V1HISTSEGVG_DB_SELECT_1_Query1)
        {
            var ths = m_310_000_SELECT_V1HISTSEGVG_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_310_000_SELECT_V1HISTSEGVG_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_310_000_SELECT_V1HISTSEGVG_DB_SELECT_1_Query1();
            var i = 0;
            dta.HHOCORR_HISTORICO = result[i++].Value?.ToString();
            return dta;
        }

    }
}