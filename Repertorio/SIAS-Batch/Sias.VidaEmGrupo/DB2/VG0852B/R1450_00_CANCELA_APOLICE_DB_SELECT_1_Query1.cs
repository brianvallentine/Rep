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
    public class R1450_00_CANCELA_APOLICE_DB_SELECT_1_Query1 : QueryBasis<R1450_00_CANCELA_APOLICE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT TIPO_APOLICE
            INTO :APOLICES-TIPO-APOLICE
            FROM SEGUROS.APOLICES
            WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT TIPO_APOLICE
											FROM SEGUROS.APOLICES
											WHERE NUM_APOLICE = '{this.PROPOVA_NUM_APOLICE}'
											WITH UR";

            return query;
        }
        public string APOLICES_TIPO_APOLICE { get; set; }
        public string PROPOVA_NUM_APOLICE { get; set; }

        public static R1450_00_CANCELA_APOLICE_DB_SELECT_1_Query1 Execute(R1450_00_CANCELA_APOLICE_DB_SELECT_1_Query1 r1450_00_CANCELA_APOLICE_DB_SELECT_1_Query1)
        {
            var ths = r1450_00_CANCELA_APOLICE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1450_00_CANCELA_APOLICE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1450_00_CANCELA_APOLICE_DB_SELECT_1_Query1();
            var i = 0;
            dta.APOLICES_TIPO_APOLICE = result[i++].Value?.ToString();
            return dta;
        }

    }
}