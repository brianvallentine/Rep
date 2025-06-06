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
    public class R3130_00_INSERT_VGHISTRAMCOB_DB_INSERT_1_Insert1 : QueryBasis<R3130_00_INSERT_VGHISTRAMCOB_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.VG_HIST_RAMO_COB
            VALUES (:DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF,
            1,
            :VGPLAR-NUM-RAMO,
            :VGPLAR-NUM-COBERTURA,
            :VGPLAR-QTD-COBERTURA,
            :VGPLAR-IMPSEGURADA,
            :VGPLAR-CUSTO,
            :VGPLAR-PREMIO)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.VG_HIST_RAMO_COB VALUES ({FieldThreatment(this.PROPOFID_NUM_PROPOSTA_SIVPF)}, 1, {FieldThreatment(this.VGPLAR_NUM_RAMO)}, {FieldThreatment(this.VGPLAR_NUM_COBERTURA)}, {FieldThreatment(this.VGPLAR_QTD_COBERTURA)}, {FieldThreatment(this.VGPLAR_IMPSEGURADA)}, {FieldThreatment(this.VGPLAR_CUSTO)}, {FieldThreatment(this.VGPLAR_PREMIO)})";

            return query;
        }
        public string PROPOFID_NUM_PROPOSTA_SIVPF { get; set; }
        public string VGPLAR_NUM_RAMO { get; set; }
        public string VGPLAR_NUM_COBERTURA { get; set; }
        public string VGPLAR_QTD_COBERTURA { get; set; }
        public string VGPLAR_IMPSEGURADA { get; set; }
        public string VGPLAR_CUSTO { get; set; }
        public string VGPLAR_PREMIO { get; set; }

        public static void Execute(R3130_00_INSERT_VGHISTRAMCOB_DB_INSERT_1_Insert1 r3130_00_INSERT_VGHISTRAMCOB_DB_INSERT_1_Insert1)
        {
            var ths = r3130_00_INSERT_VGHISTRAMCOB_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3130_00_INSERT_VGHISTRAMCOB_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}