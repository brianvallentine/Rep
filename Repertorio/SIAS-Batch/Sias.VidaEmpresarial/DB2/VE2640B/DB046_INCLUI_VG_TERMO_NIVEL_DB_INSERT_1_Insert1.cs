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
    public class DB046_INCLUI_VG_TERMO_NIVEL_DB_INSERT_1_Insert1 : QueryBasis<DB046_INCLUI_VG_TERMO_NIVEL_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.VG_TERMO_NIVEL
            (NUM_PROPOSTA_SIVPF,
            DTH_INI_VIGENCIA,
            NUM_NIVEL_CARGO,
            DTH_FIM_VIGENCIA,
            IMP_SEGURADA,
            VLR_PRM_INDIVIDUAL,
            COD_USUARIO,
            DTH_TIMESTAMP,
            QTD_VIDAS)
            VALUES
            (:VGTERNIV-NUM-PROPOSTA-SIVPF,
            :VGTERNIV-DTH-INI-VIGENCIA,
            :VGTERNIV-NUM-NIVEL-CARGO,
            :VGTERNIV-DTH-FIM-VIGENCIA,
            :VGTERNIV-IMP-SEGURADA,
            :VGTERNIV-VLR-PRM-INDIVIDUAL,
            :VGTERNIV-COD-USUARIO,
            CURRENT TIMESTAMP,
            :VGTERNIV-QTD-VIDAS)
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.VG_TERMO_NIVEL (NUM_PROPOSTA_SIVPF, DTH_INI_VIGENCIA, NUM_NIVEL_CARGO, DTH_FIM_VIGENCIA, IMP_SEGURADA, VLR_PRM_INDIVIDUAL, COD_USUARIO, DTH_TIMESTAMP, QTD_VIDAS) VALUES ({FieldThreatment(this.VGTERNIV_NUM_PROPOSTA_SIVPF)}, {FieldThreatment(this.VGTERNIV_DTH_INI_VIGENCIA)}, {FieldThreatment(this.VGTERNIV_NUM_NIVEL_CARGO)}, {FieldThreatment(this.VGTERNIV_DTH_FIM_VIGENCIA)}, {FieldThreatment(this.VGTERNIV_IMP_SEGURADA)}, {FieldThreatment(this.VGTERNIV_VLR_PRM_INDIVIDUAL)}, {FieldThreatment(this.VGTERNIV_COD_USUARIO)}, CURRENT TIMESTAMP, {FieldThreatment(this.VGTERNIV_QTD_VIDAS)})";

            return query;
        }
        public string VGTERNIV_NUM_PROPOSTA_SIVPF { get; set; }
        public string VGTERNIV_DTH_INI_VIGENCIA { get; set; }
        public string VGTERNIV_NUM_NIVEL_CARGO { get; set; }
        public string VGTERNIV_DTH_FIM_VIGENCIA { get; set; }
        public string VGTERNIV_IMP_SEGURADA { get; set; }
        public string VGTERNIV_VLR_PRM_INDIVIDUAL { get; set; }
        public string VGTERNIV_COD_USUARIO { get; set; }
        public string VGTERNIV_QTD_VIDAS { get; set; }

        public static void Execute(DB046_INCLUI_VG_TERMO_NIVEL_DB_INSERT_1_Insert1 dB046_INCLUI_VG_TERMO_NIVEL_DB_INSERT_1_Insert1)
        {
            var ths = dB046_INCLUI_VG_TERMO_NIVEL_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override DB046_INCLUI_VG_TERMO_NIVEL_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}