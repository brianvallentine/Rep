using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0601B
{
    public class R1300_00_SELECT_FUNCIOCEF_DB_SELECT_1_Query1 : QueryBasis<R1300_00_SELECT_FUNCIOCEF_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOME_FUNCIONARIO
            INTO :DCLFUNCIONARIOS-CEF.FUNCICEF-NOME-FUNCIONARIO
            FROM SEGUROS.FUNCIONARIOS_CEF
            WHERE NUM_MATRICULA =
            :DCLPROPOSTA-FIDELIZ.PROPOFID-NRMATRVEN
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOME_FUNCIONARIO
											FROM SEGUROS.FUNCIONARIOS_CEF
											WHERE NUM_MATRICULA =
											'{this.PROPOFID_NRMATRVEN}'";

            return query;
        }
        public string FUNCICEF_NOME_FUNCIONARIO { get; set; }
        public string PROPOFID_NRMATRVEN { get; set; }

        public static R1300_00_SELECT_FUNCIOCEF_DB_SELECT_1_Query1 Execute(R1300_00_SELECT_FUNCIOCEF_DB_SELECT_1_Query1 r1300_00_SELECT_FUNCIOCEF_DB_SELECT_1_Query1)
        {
            var ths = r1300_00_SELECT_FUNCIOCEF_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1300_00_SELECT_FUNCIOCEF_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1300_00_SELECT_FUNCIOCEF_DB_SELECT_1_Query1();
            var i = 0;
            dta.FUNCICEF_NOME_FUNCIONARIO = result[i++].Value?.ToString();
            return dta;
        }

    }
}