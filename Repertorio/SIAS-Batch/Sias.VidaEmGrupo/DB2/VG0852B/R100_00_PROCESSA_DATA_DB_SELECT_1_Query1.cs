using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0852B
{
    public class R100_00_PROCESSA_DATA_DB_SELECT_1_Query1 : QueryBasis<R100_00_PROCESSA_DATA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CURRENT DATE,
            CURRENT DATE - 15 DAYS,
            DATA_MOV_ABERTO
            INTO :V1SIST-DTVENFIM-VE,
            :V1SIST-DTVENFIM-CN,
            :SISTEMAS-DATA-MOV-ABERTO
            FROM SEGUROS.SISTEMAS
            WHERE IDE_SISTEMA = 'VA'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT CURRENT DATE
							,
											CURRENT DATE - 15 DAYS
							,
											DATA_MOV_ABERTO
											FROM SEGUROS.SISTEMAS
											WHERE IDE_SISTEMA = 'VA'
											WITH UR";

            return query;
        }
        public string V1SIST_DTVENFIM_VE { get; set; }
        public string V1SIST_DTVENFIM_CN { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }

        public static R100_00_PROCESSA_DATA_DB_SELECT_1_Query1 Execute(R100_00_PROCESSA_DATA_DB_SELECT_1_Query1 r100_00_PROCESSA_DATA_DB_SELECT_1_Query1)
        {
            var ths = r100_00_PROCESSA_DATA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R100_00_PROCESSA_DATA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R100_00_PROCESSA_DATA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1SIST_DTVENFIM_VE = result[i++].Value?.ToString();
            dta.V1SIST_DTVENFIM_CN = result[i++].Value?.ToString();
            dta.SISTEMAS_DATA_MOV_ABERTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}