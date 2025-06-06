using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0061B
{
    public class R1600_00_PROCESSA_CURSOR01_DB_SELECT_1_Query1 : QueryBasis<R1600_00_PROCESSA_CURSOR01_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.NUM_CERTIFICADO,
            COUNT(*)
            INTO :ERRPROVI-NUM-CERTIFICADO,
            :WS-COUNT
            FROM SEGUROS.VG_CRITICA_PROPOSTA A,
            SEGUROS.VG_DM_MSG_CRITICA B
            WHERE A.NUM_CERTIFICADO = :ERRPROVI-NUM-CERTIFICADO
            AND A.COD_MSG_CRITICA NOT IN (508, 1703, 1800, 1815)
            AND A.STA_CRITICA IN ( '0' , '1' , '2' , '4' , '5' , '8' )
            AND A.COD_MSG_CRITICA = B.COD_MSG_CRITICA
            AND B.COD_TP_MSG_CRITICA <> '3'
            GROUP BY NUM_CERTIFICADO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.NUM_CERTIFICADO
							,
											COUNT(*)
											FROM SEGUROS.VG_CRITICA_PROPOSTA A
							,
											SEGUROS.VG_DM_MSG_CRITICA B
											WHERE A.NUM_CERTIFICADO = '{this.ERRPROVI_NUM_CERTIFICADO}'
											AND A.COD_MSG_CRITICA NOT IN (508
							, 1703
							, 1800
							, 1815)
											AND A.STA_CRITICA IN ( '0' 
							, '1' 
							, '2' 
							, '4' 
							, '5' 
							, '8' )
											AND A.COD_MSG_CRITICA = B.COD_MSG_CRITICA
											AND B.COD_TP_MSG_CRITICA <> '3'
											GROUP BY NUM_CERTIFICADO
											WITH UR";

            return query;
        }
        public string ERRPROVI_NUM_CERTIFICADO { get; set; }
        public string WS_COUNT { get; set; }

        public static R1600_00_PROCESSA_CURSOR01_DB_SELECT_1_Query1 Execute(R1600_00_PROCESSA_CURSOR01_DB_SELECT_1_Query1 r1600_00_PROCESSA_CURSOR01_DB_SELECT_1_Query1)
        {
            var ths = r1600_00_PROCESSA_CURSOR01_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1600_00_PROCESSA_CURSOR01_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1600_00_PROCESSA_CURSOR01_DB_SELECT_1_Query1();
            var i = 0;
            dta.ERRPROVI_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.WS_COUNT = result[i++].Value?.ToString();
            return dta;
        }

    }
}