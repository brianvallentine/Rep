using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.RE0001S
{
    public class R0800_00_SELECT_V0PARC_COMPL_DB_SELECT_1_Query1 : QueryBasis<R0800_00_SELECT_V0PARC_COMPL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            VALUE(SUM(VLR_COMPLEMENTO),+0),
            VALUE(SUM(VLR_COMPLEMENT_IX),+0)
            INTO :V0PCMP-VLR-COMPL,
            :V0PCMP-VLR-COMPL-I
            FROM SEGUROS.V0PARCELA_COMPL
            WHERE NUM_APOLICE = :WHOST-NUM-APOL
            AND NRENDOS = :WHOST-NRENDOS
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											VALUE(SUM(VLR_COMPLEMENTO)
							,+0)
							,
											VALUE(SUM(VLR_COMPLEMENT_IX)
							,+0)
											FROM SEGUROS.V0PARCELA_COMPL
											WHERE NUM_APOLICE = '{this.WHOST_NUM_APOL}'
											AND NRENDOS = '{this.WHOST_NRENDOS}'
											WITH UR";

            return query;
        }
        public string V0PCMP_VLR_COMPL { get; set; }
        public string V0PCMP_VLR_COMPL_I { get; set; }
        public string WHOST_NUM_APOL { get; set; }
        public string WHOST_NRENDOS { get; set; }

        public static R0800_00_SELECT_V0PARC_COMPL_DB_SELECT_1_Query1 Execute(R0800_00_SELECT_V0PARC_COMPL_DB_SELECT_1_Query1 r0800_00_SELECT_V0PARC_COMPL_DB_SELECT_1_Query1)
        {
            var ths = r0800_00_SELECT_V0PARC_COMPL_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0800_00_SELECT_V0PARC_COMPL_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0800_00_SELECT_V0PARC_COMPL_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0PCMP_VLR_COMPL = result[i++].Value?.ToString();
            dta.V0PCMP_VLR_COMPL_I = result[i++].Value?.ToString();
            return dta;
        }

    }
}