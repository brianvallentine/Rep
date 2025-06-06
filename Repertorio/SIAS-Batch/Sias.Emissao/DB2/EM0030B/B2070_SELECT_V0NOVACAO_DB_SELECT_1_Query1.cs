using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0030B
{
    public class B2070_SELECT_V0NOVACAO_DB_SELECT_1_Query1 : QueryBasis<B2070_SELECT_V0NOVACAO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(SUM(VAL_IOF_MIP),0),
            VALUE(SUM(VAL_IOF_DFI),0)
            INTO :V0NOVA-VL-IOF-MIP,
            :V0NOVA-VL-IOF-DFI
            FROM SEGUROS.V0NOVACAO
            WHERE NUM_APOLICE = :ENDO-NUM-APOLICE
            AND NRENDOS = :ENDO-NRENDOS
            AND DTMOVTO = :ENDO-DTINIVIG
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(SUM(VAL_IOF_MIP)
							,0)
							,
											VALUE(SUM(VAL_IOF_DFI)
							,0)
											FROM SEGUROS.V0NOVACAO
											WHERE NUM_APOLICE = '{this.ENDO_NUM_APOLICE}'
											AND NRENDOS = '{this.ENDO_NRENDOS}'
											AND DTMOVTO = '{this.ENDO_DTINIVIG}'
											WITH UR";

            return query;
        }
        public string V0NOVA_VL_IOF_MIP { get; set; }
        public string V0NOVA_VL_IOF_DFI { get; set; }
        public string ENDO_NUM_APOLICE { get; set; }
        public string ENDO_DTINIVIG { get; set; }
        public string ENDO_NRENDOS { get; set; }

        public static B2070_SELECT_V0NOVACAO_DB_SELECT_1_Query1 Execute(B2070_SELECT_V0NOVACAO_DB_SELECT_1_Query1 b2070_SELECT_V0NOVACAO_DB_SELECT_1_Query1)
        {
            var ths = b2070_SELECT_V0NOVACAO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override B2070_SELECT_V0NOVACAO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new B2070_SELECT_V0NOVACAO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0NOVA_VL_IOF_MIP = result[i++].Value?.ToString();
            dta.V0NOVA_VL_IOF_DFI = result[i++].Value?.ToString();
            return dta;
        }

    }
}