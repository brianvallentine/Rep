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
    public class M_502_000_LER_V0SEGURAVG_DB_SELECT_1_Query1 : QueryBasis<M_502_000_LER_V0SEGURAVG_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(COUNT(*),0)
            INTO :WHOST-QTDE-SEGVG
            FROM SEGUROS.V0SEGURAVG
            WHERE NUM_APOLICE = :WHOST-APOLICE
            AND COD_SUBGRUPO = :WHOST-SUBGRUPO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(COUNT(*)
							,0)
											FROM SEGUROS.V0SEGURAVG
											WHERE NUM_APOLICE = '{this.WHOST_APOLICE}'
											AND COD_SUBGRUPO = '{this.WHOST_SUBGRUPO}'";

            return query;
        }
        public string WHOST_QTDE_SEGVG { get; set; }
        public string WHOST_SUBGRUPO { get; set; }
        public string WHOST_APOLICE { get; set; }

        public static M_502_000_LER_V0SEGURAVG_DB_SELECT_1_Query1 Execute(M_502_000_LER_V0SEGURAVG_DB_SELECT_1_Query1 m_502_000_LER_V0SEGURAVG_DB_SELECT_1_Query1)
        {
            var ths = m_502_000_LER_V0SEGURAVG_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_502_000_LER_V0SEGURAVG_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_502_000_LER_V0SEGURAVG_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_QTDE_SEGVG = result[i++].Value?.ToString();
            return dta;
        }

    }
}