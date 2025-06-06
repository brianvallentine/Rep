using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0816B
{
    public class R0510_00_INSERT_HISTCONTABIL_DB_INSERT_1_Insert1 : QueryBasis<R0510_00_INSERT_HISTCONTABIL_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0HISTCONTABILVA
            VALUES (:V0HCOB-NRCERTIF
            ,:V0HCOB-NRPARCEL
            ,:V0MOVC-NRTIT
            ,:V0HCOB-OCORHIST
            ,:V0PROP-NUM-APOLICE
            ,:V0PROP-CODSUBES
            ,:V0PROP-FONTE
            , 0
            ,:V0HCTVA-PRMVG
            ,:V0HCTVA-PRMAP
            ,:V0SIST-DTMOVABE
            , '0'
            ,:V0HCTB-CODOPER
            ,CURRENT TIMESTAMP
            ,NULL)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0HISTCONTABILVA VALUES ({FieldThreatment(this.V0HCOB_NRCERTIF)} ,{FieldThreatment(this.V0HCOB_NRPARCEL)} ,{FieldThreatment(this.V0MOVC_NRTIT)} ,{FieldThreatment(this.V0HCOB_OCORHIST)} ,{FieldThreatment(this.V0PROP_NUM_APOLICE)} ,{FieldThreatment(this.V0PROP_CODSUBES)} ,{FieldThreatment(this.V0PROP_FONTE)} , 0 ,{FieldThreatment(this.V0HCTVA_PRMVG)} ,{FieldThreatment(this.V0HCTVA_PRMAP)} ,{FieldThreatment(this.V0SIST_DTMOVABE)} , '0' ,{FieldThreatment(this.V0HCTB_CODOPER)} ,CURRENT TIMESTAMP ,NULL)";

            return query;
        }
        public string V0HCOB_NRCERTIF { get; set; }
        public string V0HCOB_NRPARCEL { get; set; }
        public string V0MOVC_NRTIT { get; set; }
        public string V0HCOB_OCORHIST { get; set; }
        public string V0PROP_NUM_APOLICE { get; set; }
        public string V0PROP_CODSUBES { get; set; }
        public string V0PROP_FONTE { get; set; }
        public string V0HCTVA_PRMVG { get; set; }
        public string V0HCTVA_PRMAP { get; set; }
        public string V0SIST_DTMOVABE { get; set; }
        public string V0HCTB_CODOPER { get; set; }

        public static void Execute(R0510_00_INSERT_HISTCONTABIL_DB_INSERT_1_Insert1 r0510_00_INSERT_HISTCONTABIL_DB_INSERT_1_Insert1)
        {
            var ths = r0510_00_INSERT_HISTCONTABIL_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0510_00_INSERT_HISTCONTABIL_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}