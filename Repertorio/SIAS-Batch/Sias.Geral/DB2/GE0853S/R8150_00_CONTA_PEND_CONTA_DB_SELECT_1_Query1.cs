using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0853S
{
    public class R8150_00_CONTA_PEND_CONTA_DB_SELECT_1_Query1 : QueryBasis<R8150_00_CONTA_PEND_CONTA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(COUNT(*),0)
            INTO :WS-QT-PARCELAS
            FROM SEGUROS.COBER_HIST_VIDAZUL
            WHERE NUM_CERTIFICADO = :V0HISC-NRCERTIF
            AND NUM_PARCELA BETWEEN :WHOST-NUM-PARCELA-I
            AND :WHOST-NUM-PARCELA-F
            AND DATA_VENCIMENTO <= :V1SIST-DTVENFIM-CN
            AND SIT_REGISTRO IN ( ' ' , '0' , X '00' )
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(COUNT(*)
							,0)
											FROM SEGUROS.COBER_HIST_VIDAZUL
											WHERE NUM_CERTIFICADO = '{this.V0HISC_NRCERTIF}'
											AND NUM_PARCELA BETWEEN '{this.WHOST_NUM_PARCELA_I}'
											AND '{this.WHOST_NUM_PARCELA_F}'
											AND DATA_VENCIMENTO <= '{this.V1SIST_DTVENFIM_CN}'
											AND SIT_REGISTRO IN ( ' ' 
							, '0' 
							, X'00' )
											WITH UR";

            return query;
        }
        public string WS_QT_PARCELAS { get; set; }
        public string WHOST_NUM_PARCELA_I { get; set; }
        public string WHOST_NUM_PARCELA_F { get; set; }
        public string V1SIST_DTVENFIM_CN { get; set; }
        public string V0HISC_NRCERTIF { get; set; }

        public static R8150_00_CONTA_PEND_CONTA_DB_SELECT_1_Query1 Execute(R8150_00_CONTA_PEND_CONTA_DB_SELECT_1_Query1 r8150_00_CONTA_PEND_CONTA_DB_SELECT_1_Query1)
        {
            var ths = r8150_00_CONTA_PEND_CONTA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R8150_00_CONTA_PEND_CONTA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R8150_00_CONTA_PEND_CONTA_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_QT_PARCELAS = result[i++].Value?.ToString();
            return dta;
        }

    }
}