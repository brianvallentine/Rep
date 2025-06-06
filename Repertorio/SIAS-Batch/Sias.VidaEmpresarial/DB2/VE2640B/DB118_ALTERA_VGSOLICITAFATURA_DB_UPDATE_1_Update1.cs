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
    public class DB118_ALTERA_VGSOLICITAFATURA_DB_UPDATE_1_Update1 : QueryBasis<DB118_ALTERA_VGSOLICITAFATURA_DB_UPDATE_1_Update1>
    {

        private VE2640B_C4_SOLICITA CurrentOf { get; set; }

        public DB118_ALTERA_VGSOLICITAFATURA_DB_UPDATE_1_Update1(VE2640B_C4_SOLICITA currentOf)
        {
            CurrentOf = currentOf;
        }

        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.VG_SOLICITA_FATURA
				SET SIT_SOLICITA =  '{this.VGSOLFAT_SIT_SOLICITA}'
				WHERE
				(
					SIT_SOLICITA IN ( '0' ) AND NUM_APOLICE IN(SELECT DISTINCT NUM_APOLICE FROM SEGUROS.VG_PRODUTO_SIAS WHERE COD_PRODUTO IN(8205,'{this.JVPRD8205}', 8209,'{this.JVPRD8209}', 9329,'{this.JVPRD9329}', 9343,'{this.JVPRD9343}' ) )
				)
				AND DIGCTADEB {FieldThreatment(CurrentOf.VGSOLFAT_NUM_APOLICE, ThreatmentType.InsertWhereField)}
				";

            return query;
        }
        public string VGSOLFAT_SIT_SOLICITA { get; set; }
        public string JVPRD8205 { get; set; }
        public string JVPRD8209 { get; set; }
        public string JVPRD9329 { get; set; }
        public string JVPRD9343 { get; set; }

        public static void Execute(DB118_ALTERA_VGSOLICITAFATURA_DB_UPDATE_1_Update1 dB118_ALTERA_VGSOLICITAFATURA_DB_UPDATE_1_Update1)
        {
            var ths = dB118_ALTERA_VGSOLICITAFATURA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override DB118_ALTERA_VGSOLICITAFATURA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}