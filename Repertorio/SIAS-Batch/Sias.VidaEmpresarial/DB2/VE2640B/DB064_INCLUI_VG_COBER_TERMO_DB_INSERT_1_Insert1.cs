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
    public class DB064_INCLUI_VG_COBER_TERMO_DB_INSERT_1_Insert1 : QueryBasis<DB064_INCLUI_VG_COBER_TERMO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.VG_COBER_TERMO
            ( NUM_PROPOSTA_SIVPF,
            DTH_INI_VIGENCIA,
            COD_GARANTIA,
            DTH_FIM_VIGENCIA,
            COD_USUARIO,
            DTH_TIMESTAMP)
            VALUES
            (:VGCOBTER-NUM-PROPOSTA-SIVPF,
            :VGCOBTER-DTH-INI-VIGENCIA,
            :VGCOBTER-COD-GARANTIA,
            :VGCOBTER-DTH-FIM-VIGENCIA,
            :VGCOBTER-COD-USUARIO,
            CURRENT TIMESTAMP)
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.VG_COBER_TERMO ( NUM_PROPOSTA_SIVPF, DTH_INI_VIGENCIA, COD_GARANTIA, DTH_FIM_VIGENCIA, COD_USUARIO, DTH_TIMESTAMP) VALUES ({FieldThreatment(this.VGCOBTER_NUM_PROPOSTA_SIVPF)}, {FieldThreatment(this.VGCOBTER_DTH_INI_VIGENCIA)}, {FieldThreatment(this.VGCOBTER_COD_GARANTIA)}, {FieldThreatment(this.VGCOBTER_DTH_FIM_VIGENCIA)}, {FieldThreatment(this.VGCOBTER_COD_USUARIO)}, CURRENT TIMESTAMP)";

            return query;
        }
        public string VGCOBTER_NUM_PROPOSTA_SIVPF { get; set; }
        public string VGCOBTER_DTH_INI_VIGENCIA { get; set; }
        public string VGCOBTER_COD_GARANTIA { get; set; }
        public string VGCOBTER_DTH_FIM_VIGENCIA { get; set; }
        public string VGCOBTER_COD_USUARIO { get; set; }

        public static void Execute(DB064_INCLUI_VG_COBER_TERMO_DB_INSERT_1_Insert1 dB064_INCLUI_VG_COBER_TERMO_DB_INSERT_1_Insert1)
        {
            var ths = dB064_INCLUI_VG_COBER_TERMO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override DB064_INCLUI_VG_COBER_TERMO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}