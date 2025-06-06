using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE0125B
{
    public class R0590_00_LER_COMPL_TERMO_DB_SELECT_1_Query1 : QueryBasis<R0590_00_LER_COMPL_TERMO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_PROPOSTA_SIVPF
            INTO :VGCOMTRO-NUM-PROPOSTA-SIVPF
            FROM SEGUROS.VG_COMPL_TERMO
            WHERE NUM_TERMO = :VGCOMTRO-NUM-TERMO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_PROPOSTA_SIVPF
											FROM SEGUROS.VG_COMPL_TERMO
											WHERE NUM_TERMO = '{this.VGCOMTRO_NUM_TERMO}'";

            return query;
        }
        public string VGCOMTRO_NUM_PROPOSTA_SIVPF { get; set; }
        public string VGCOMTRO_NUM_TERMO { get; set; }

        public static R0590_00_LER_COMPL_TERMO_DB_SELECT_1_Query1 Execute(R0590_00_LER_COMPL_TERMO_DB_SELECT_1_Query1 r0590_00_LER_COMPL_TERMO_DB_SELECT_1_Query1)
        {
            var ths = r0590_00_LER_COMPL_TERMO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0590_00_LER_COMPL_TERMO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0590_00_LER_COMPL_TERMO_DB_SELECT_1_Query1();
            var i = 0;
            dta.VGCOMTRO_NUM_PROPOSTA_SIVPF = result[i++].Value?.ToString();
            return dta;
        }

    }
}