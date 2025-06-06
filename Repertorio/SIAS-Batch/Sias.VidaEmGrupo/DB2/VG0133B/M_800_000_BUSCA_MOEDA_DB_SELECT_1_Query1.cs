using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0133B
{
    public class M_800_000_BUSCA_MOEDA_DB_SELECT_1_Query1 : QueryBasis<M_800_000_BUSCA_MOEDA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            DATA_MOVIMENTO,
            VALUE(COD_MOEDA_IMP, 0),
            VALUE(COD_MOEDA_PRM, 0)
            INTO
            :XDATA-MOVIMENTO,
            :ECOD-MOEDA-IMP,
            :ECOD-MOEDA-PRM
            FROM
            SEGUROS.V1HISTSEGVG
            WHERE
            NUM_APOLICE = :SNUM-APOLICE AND
            NUM_ITEM = :SNUM-ITEM AND
            OCORR_HISTORICO = :SOCORR-HISTORICO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											DATA_MOVIMENTO
							,
											VALUE(COD_MOEDA_IMP
							, 0)
							,
											VALUE(COD_MOEDA_PRM
							, 0)
											FROM
											SEGUROS.V1HISTSEGVG
											WHERE
											NUM_APOLICE = '{this.SNUM_APOLICE}' AND
											NUM_ITEM = '{this.SNUM_ITEM}' AND
											OCORR_HISTORICO = '{this.SOCORR_HISTORICO}'";

            return query;
        }
        public string XDATA_MOVIMENTO { get; set; }
        public string ECOD_MOEDA_IMP { get; set; }
        public string ECOD_MOEDA_PRM { get; set; }
        public string SOCORR_HISTORICO { get; set; }
        public string SNUM_APOLICE { get; set; }
        public string SNUM_ITEM { get; set; }

        public static M_800_000_BUSCA_MOEDA_DB_SELECT_1_Query1 Execute(M_800_000_BUSCA_MOEDA_DB_SELECT_1_Query1 m_800_000_BUSCA_MOEDA_DB_SELECT_1_Query1)
        {
            var ths = m_800_000_BUSCA_MOEDA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_800_000_BUSCA_MOEDA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_800_000_BUSCA_MOEDA_DB_SELECT_1_Query1();
            var i = 0;
            dta.XDATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.ECOD_MOEDA_IMP = result[i++].Value?.ToString();
            dta.ECOD_MOEDA_PRM = result[i++].Value?.ToString();
            return dta;
        }

    }
}