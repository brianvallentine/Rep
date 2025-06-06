using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE2640B
{
    public class R9978_2600_VERIFICAR_PROPOSTA_DB_SELECT_1_Query1 : QueryBasis<R9978_2600_VERIFICAR_PROPOSTA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_TERMO
            INTO :VGCOMTRO-NUM-TERMO
            FROM SEGUROS.VG_COMPL_TERMO
            WHERE NUM_PROPOSTA_SIVPF = :VGCOMTRO-NUM-PROPOSTA-SIVPF
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT NUM_TERMO
											FROM SEGUROS.VG_COMPL_TERMO
											WHERE NUM_PROPOSTA_SIVPF = '{this.VGCOMTRO_NUM_PROPOSTA_SIVPF}'";

            return query;
        }
        public string VGCOMTRO_NUM_TERMO { get; set; }
        public string VGCOMTRO_NUM_PROPOSTA_SIVPF { get; set; }

        public static R9978_2600_VERIFICAR_PROPOSTA_DB_SELECT_1_Query1 Execute(R9978_2600_VERIFICAR_PROPOSTA_DB_SELECT_1_Query1 r9978_2600_VERIFICAR_PROPOSTA_DB_SELECT_1_Query1)
        {
            var ths = r9978_2600_VERIFICAR_PROPOSTA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R9978_2600_VERIFICAR_PROPOSTA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R9978_2600_VERIFICAR_PROPOSTA_DB_SELECT_1_Query1();
            var i = 0;
            dta.VGCOMTRO_NUM_TERMO = result[i++].Value?.ToString();
            return dta;
        }

    }
}