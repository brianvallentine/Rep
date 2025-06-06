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
    public class DB148_ACESSA_VGCOBERTERMO_DB_SELECT_1_Query1 : QueryBasis<DB148_ACESSA_VGCOBERTERMO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_GARANTIA
            INTO :VGCOBTER-COD-GARANTIA
            FROM SEGUROS.VG_COBER_TERMO
            WHERE NUM_PROPOSTA_SIVPF = :VGCOMTRO-NUM-PROPOSTA-SIVPF
            AND COD_GARANTIA = :H-COD-GARANTIA
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT COD_GARANTIA
											FROM SEGUROS.VG_COBER_TERMO
											WHERE NUM_PROPOSTA_SIVPF = '{this.VGCOMTRO_NUM_PROPOSTA_SIVPF}'
											AND COD_GARANTIA = '{this.H_COD_GARANTIA}'
											WITH UR";

            return query;
        }
        public string VGCOBTER_COD_GARANTIA { get; set; }
        public string VGCOMTRO_NUM_PROPOSTA_SIVPF { get; set; }
        public string H_COD_GARANTIA { get; set; }

        public static DB148_ACESSA_VGCOBERTERMO_DB_SELECT_1_Query1 Execute(DB148_ACESSA_VGCOBERTERMO_DB_SELECT_1_Query1 dB148_ACESSA_VGCOBERTERMO_DB_SELECT_1_Query1)
        {
            var ths = dB148_ACESSA_VGCOBERTERMO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override DB148_ACESSA_VGCOBERTERMO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new DB148_ACESSA_VGCOBERTERMO_DB_SELECT_1_Query1();
            var i = 0;
            dta.VGCOBTER_COD_GARANTIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}