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
    public class DB112_ACESSA_VG_COMPL_TERMO_DB_SELECT_1_Query1 : QueryBasis<DB112_ACESSA_VG_COMPL_TERMO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_PROPOSTA_SIVPF,
            NUM_CARTAO_CREDITO
            INTO :VGCOMTRO-NUM-PROPOSTA-SIVPF,
            :VGCOMTRO-NUM-CARTAO-CREDITO
            FROM SEGUROS.VG_COMPL_TERMO
            WHERE NUM_TERMO = :TERMOADE-NUM-TERMO
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT NUM_PROPOSTA_SIVPF
							,
											NUM_CARTAO_CREDITO
											FROM SEGUROS.VG_COMPL_TERMO
											WHERE NUM_TERMO = '{this.TERMOADE_NUM_TERMO}'";

            return query;
        }
        public string VGCOMTRO_NUM_PROPOSTA_SIVPF { get; set; }
        public string VGCOMTRO_NUM_CARTAO_CREDITO { get; set; }
        public string TERMOADE_NUM_TERMO { get; set; }

        public static DB112_ACESSA_VG_COMPL_TERMO_DB_SELECT_1_Query1 Execute(DB112_ACESSA_VG_COMPL_TERMO_DB_SELECT_1_Query1 dB112_ACESSA_VG_COMPL_TERMO_DB_SELECT_1_Query1)
        {
            var ths = dB112_ACESSA_VG_COMPL_TERMO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override DB112_ACESSA_VG_COMPL_TERMO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new DB112_ACESSA_VG_COMPL_TERMO_DB_SELECT_1_Query1();
            var i = 0;
            dta.VGCOMTRO_NUM_PROPOSTA_SIVPF = result[i++].Value?.ToString();
            dta.VGCOMTRO_NUM_CARTAO_CREDITO = result[i++].Value?.ToString();
            return dta;
        }

    }
}