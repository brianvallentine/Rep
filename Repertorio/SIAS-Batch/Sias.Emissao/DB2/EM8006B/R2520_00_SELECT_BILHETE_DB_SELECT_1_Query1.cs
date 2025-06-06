using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM8006B
{
    public class R2520_00_SELECT_BILHETE_DB_SELECT_1_Query1 : QueryBasis<R2520_00_SELECT_BILHETE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            NUM_PROPOSTA_SIVPF
            INTO
            :PROPOFID-NUM-PROPOSTA-SIVPF
            FROM SEGUROS.BILHETE A
            ,SEGUROS.PROPOSTA_FIDELIZ B
            WHERE A.NUM_APOLICE = :BILHETE-NUM-APOLICE
            AND A.NUM_BILHETE = B.NUM_SICOB
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											NUM_PROPOSTA_SIVPF
											FROM SEGUROS.BILHETE A
											,SEGUROS.PROPOSTA_FIDELIZ B
											WHERE A.NUM_APOLICE = '{this.BILHETE_NUM_APOLICE}'
											AND A.NUM_BILHETE = B.NUM_SICOB
											WITH UR";

            return query;
        }
        public string PROPOFID_NUM_PROPOSTA_SIVPF { get; set; }
        public string BILHETE_NUM_APOLICE { get; set; }

        public static R2520_00_SELECT_BILHETE_DB_SELECT_1_Query1 Execute(R2520_00_SELECT_BILHETE_DB_SELECT_1_Query1 r2520_00_SELECT_BILHETE_DB_SELECT_1_Query1)
        {
            var ths = r2520_00_SELECT_BILHETE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2520_00_SELECT_BILHETE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2520_00_SELECT_BILHETE_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPOFID_NUM_PROPOSTA_SIVPF = result[i++].Value?.ToString();
            return dta;
        }

    }
}