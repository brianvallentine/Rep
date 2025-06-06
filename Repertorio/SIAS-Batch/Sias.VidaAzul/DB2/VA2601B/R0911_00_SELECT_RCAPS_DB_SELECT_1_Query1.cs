using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2601B
{
    public class R0911_00_SELECT_RCAPS_DB_SELECT_1_Query1 : QueryBasis<R0911_00_SELECT_RCAPS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOME_SEGURADO ,
            AGE_COBRANCA
            INTO :RCAPS-NOME-SEGURADO,
            :RCAPS-AGE-COBRANCA
            FROM SEGUROS.RCAPS
            WHERE NUM_CERTIFICADO = :PROPOFID-NUM-PROPOSTA-SIVPF
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOME_SEGURADO 
							,
											AGE_COBRANCA
											FROM SEGUROS.RCAPS
											WHERE NUM_CERTIFICADO = '{this.PROPOFID_NUM_PROPOSTA_SIVPF}'";

            return query;
        }
        public string RCAPS_NOME_SEGURADO { get; set; }
        public string RCAPS_AGE_COBRANCA { get; set; }
        public string PROPOFID_NUM_PROPOSTA_SIVPF { get; set; }

        public static R0911_00_SELECT_RCAPS_DB_SELECT_1_Query1 Execute(R0911_00_SELECT_RCAPS_DB_SELECT_1_Query1 r0911_00_SELECT_RCAPS_DB_SELECT_1_Query1)
        {
            var ths = r0911_00_SELECT_RCAPS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0911_00_SELECT_RCAPS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0911_00_SELECT_RCAPS_DB_SELECT_1_Query1();
            var i = 0;
            dta.RCAPS_NOME_SEGURADO = result[i++].Value?.ToString();
            dta.RCAPS_AGE_COBRANCA = result[i++].Value?.ToString();
            return dta;
        }

    }
}