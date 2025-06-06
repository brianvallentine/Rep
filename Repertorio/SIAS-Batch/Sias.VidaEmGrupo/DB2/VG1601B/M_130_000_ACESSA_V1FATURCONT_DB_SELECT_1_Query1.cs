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
    public class M_130_000_ACESSA_V1FATURCONT_DB_SELECT_1_Query1 : QueryBasis<M_130_000_ACESSA_V1FATURCONT_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE ,
            COD_SUBGRUPO ,
            DATA_REFERENCIA
            INTO :FATCON-NUM-APOL,
            :FATCON-COD-SUBG,
            :FATCON-DATA-REFER
            FROM SEGUROS.V1FATURCONT
            WHERE NUM_APOLICE = :FATCON-NUM-APOL
            AND COD_SUBGRUPO = :FATCON-COD-SUBG
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE 
							,
											COD_SUBGRUPO 
							,
											DATA_REFERENCIA
											FROM SEGUROS.V1FATURCONT
											WHERE NUM_APOLICE = '{this.FATCON_NUM_APOL}'
											AND COD_SUBGRUPO = '{this.FATCON_COD_SUBG}'";

            return query;
        }
        public string FATCON_NUM_APOL { get; set; }
        public string FATCON_COD_SUBG { get; set; }
        public string FATCON_DATA_REFER { get; set; }

        public static M_130_000_ACESSA_V1FATURCONT_DB_SELECT_1_Query1 Execute(M_130_000_ACESSA_V1FATURCONT_DB_SELECT_1_Query1 m_130_000_ACESSA_V1FATURCONT_DB_SELECT_1_Query1)
        {
            var ths = m_130_000_ACESSA_V1FATURCONT_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_130_000_ACESSA_V1FATURCONT_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_130_000_ACESSA_V1FATURCONT_DB_SELECT_1_Query1();
            var i = 0;
            dta.FATCON_NUM_APOL = result[i++].Value?.ToString();
            dta.FATCON_COD_SUBG = result[i++].Value?.ToString();
            dta.FATCON_DATA_REFER = result[i++].Value?.ToString();
            return dta;
        }

    }
}