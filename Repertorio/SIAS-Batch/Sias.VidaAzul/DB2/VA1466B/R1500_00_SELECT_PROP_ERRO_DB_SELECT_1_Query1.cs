using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA1466B
{
    public class R1500_00_SELECT_PROP_ERRO_DB_SELECT_1_Query1 : QueryBasis<R1500_00_SELECT_PROP_ERRO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SUBSTR(VALUE(T2.DES_ABREV_MSG_CRITICA, ' ' ),1,40)
            INTO :WS-DESCR-ERRO
            FROM SEGUROS.VG_CRITICA_PROPOSTA T1,
            SEGUROS.VG_DM_MSG_CRITICA T2
            WHERE T1.NUM_CERTIFICADO = :V0PROP-NRCERTIF
            AND T1.STA_CRITICA IN ( '0' , '1' , '2' , '4' , '5' , '8' )
            AND T1.COD_MSG_CRITICA = T2.COD_MSG_CRITICA
            AND T2.COD_TP_MSG_CRITICA <> '3'
            FETCH FIRST 1 ROW ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SUBSTR(VALUE(T2.DES_ABREV_MSG_CRITICA
							, ' ' )
							,1
							,40)
											FROM SEGUROS.VG_CRITICA_PROPOSTA T1
							,
											SEGUROS.VG_DM_MSG_CRITICA T2
											WHERE T1.NUM_CERTIFICADO = '{this.V0PROP_NRCERTIF}'
											AND T1.STA_CRITICA IN ( '0' 
							, '1' 
							, '2' 
							, '4' 
							, '5' 
							, '8' )
											AND T1.COD_MSG_CRITICA = T2.COD_MSG_CRITICA
											AND T2.COD_TP_MSG_CRITICA <> '3'
											FETCH FIRST 1 ROW ONLY
											WITH UR";

            return query;
        }
        public string WS_DESCR_ERRO { get; set; }
        public string V0PROP_NRCERTIF { get; set; }

        public static R1500_00_SELECT_PROP_ERRO_DB_SELECT_1_Query1 Execute(R1500_00_SELECT_PROP_ERRO_DB_SELECT_1_Query1 r1500_00_SELECT_PROP_ERRO_DB_SELECT_1_Query1)
        {
            var ths = r1500_00_SELECT_PROP_ERRO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1500_00_SELECT_PROP_ERRO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1500_00_SELECT_PROP_ERRO_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_DESCR_ERRO = result[i++].Value?.ToString();
            return dta;
        }

    }
}