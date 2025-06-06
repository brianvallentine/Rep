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
    public class R2230_00_SELECT_PESSOA_FONE_DB_SELECT_3_Query1 : QueryBasis<R2230_00_SELECT_PESSOA_FONE_DB_SELECT_3_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DDD,
            NUM_FONE
            INTO :WHOST-DDD-CELULAR,
            :WHOST-FONE-CELULAR
            FROM SEGUROS.PESSOA_TELEFONE
            WHERE COD_PESSOA =
            :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PESSOA
            AND TIPO_FONE = 3
            ORDER BY SEQ_FONE DESC
            FETCH FIRST ROWS ONLY
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DDD
							,
											NUM_FONE
											FROM SEGUROS.PESSOA_TELEFONE
											WHERE COD_PESSOA =
											'{this.PROPOFID_COD_PESSOA}'
											AND TIPO_FONE = 3
											ORDER BY SEQ_FONE DESC
											FETCH FIRST ROWS ONLY";

            return query;
        }
        public string WHOST_DDD_CELULAR { get; set; }
        public string WHOST_FONE_CELULAR { get; set; }
        public string PROPOFID_COD_PESSOA { get; set; }

        public static R2230_00_SELECT_PESSOA_FONE_DB_SELECT_3_Query1 Execute(R2230_00_SELECT_PESSOA_FONE_DB_SELECT_3_Query1 r2230_00_SELECT_PESSOA_FONE_DB_SELECT_3_Query1)
        {
            var ths = r2230_00_SELECT_PESSOA_FONE_DB_SELECT_3_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2230_00_SELECT_PESSOA_FONE_DB_SELECT_3_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2230_00_SELECT_PESSOA_FONE_DB_SELECT_3_Query1();
            var i = 0;
            dta.WHOST_DDD_CELULAR = result[i++].Value?.ToString();
            dta.WHOST_FONE_CELULAR = result[i++].Value?.ToString();
            return dta;
        }

    }
}