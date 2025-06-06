using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1601B
{
    public class M_820_000_ACESSA_HISTSEGVG_DB_SELECT_1_Query1 : QueryBasis<M_820_000_ACESSA_HISTSEGVG_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            VALUE(COD_MOEDA_IMP,01),
            VALUE(COD_MOEDA_PRM,01)
            INTO
            :ECOD-MOEDA-IMP,
            :ECOD-MOEDA-PRM
            FROM
            SEGUROS.SEGURADOSVGAP_HIST
            WHERE
            NUM_APOLICE = :SEGURVGA-NUM-APOLICE AND
            NUM_ITEM = :SEGURVGA-NUM-ITEM AND
            OCORR_HISTORICO = :SEGURVGA-OCORR-HISTORICO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											VALUE(COD_MOEDA_IMP
							,01)
							,
											VALUE(COD_MOEDA_PRM
							,01)
											FROM
											SEGUROS.SEGURADOSVGAP_HIST
											WHERE
											NUM_APOLICE = '{this.SEGURVGA_NUM_APOLICE}' AND
											NUM_ITEM = '{this.SEGURVGA_NUM_ITEM}' AND
											OCORR_HISTORICO = '{this.SEGURVGA_OCORR_HISTORICO}'";

            return query;
        }
        public string ECOD_MOEDA_IMP { get; set; }
        public string ECOD_MOEDA_PRM { get; set; }
        public string SEGURVGA_OCORR_HISTORICO { get; set; }
        public string SEGURVGA_NUM_APOLICE { get; set; }
        public string SEGURVGA_NUM_ITEM { get; set; }

        public static M_820_000_ACESSA_HISTSEGVG_DB_SELECT_1_Query1 Execute(M_820_000_ACESSA_HISTSEGVG_DB_SELECT_1_Query1 m_820_000_ACESSA_HISTSEGVG_DB_SELECT_1_Query1)
        {
            var ths = m_820_000_ACESSA_HISTSEGVG_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_820_000_ACESSA_HISTSEGVG_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_820_000_ACESSA_HISTSEGVG_DB_SELECT_1_Query1();
            var i = 0;
            dta.ECOD_MOEDA_IMP = result[i++].Value?.ToString();
            dta.ECOD_MOEDA_PRM = result[i++].Value?.ToString();
            return dta;
        }

    }
}