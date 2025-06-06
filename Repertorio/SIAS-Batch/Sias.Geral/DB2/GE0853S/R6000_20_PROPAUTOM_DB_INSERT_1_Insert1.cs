using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0853S
{
    public class R6000_20_PROPAUTOM_DB_INSERT_1_Insert1 : QueryBasis<R6000_20_PROPAUTOM_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0MOVIMENTO
            VALUES (:V0PROP-NUM-APOLICE,
            :V0PROP-CODSUBES,
            :V0PROP-FONTE,
            :V0FONT-PROPAUTOM,
            '1' ,
            :V0PROP-NRCERTIF,
            ' ' ,
            :V0SEGU-TPINCLUS,
            :V0PROP-CODCLIEN,
            :V0SEGU-AGENCIADOR,
            0,
            0,
            0,
            0,
            'S' ,
            'N' ,
            :V0OPCP-PERIPGTO,
            12,
            ' ' ,
            ' ' ,
            ' ' ,
            0,
            ' ' ,
            1,
            1,
            104,
            0,
            ' ' ,
            :V0PROP-NRMATRFUN,
            0,
            ' ' ,
            0,
            ' ' ,
            '1' ,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            :V0COBA-IMPMORNATU,
            :V0COBA-IMPMORNATU,
            :V0COBA-IMPMORACID,
            :V0COBA-IMPMORACID,
            :V0COBA-IMPINVPERM,
            :V0COBA-IMPINVPERM,
            0,
            0,
            0,
            0,
            :V0COBA-IMPDIT,
            :V0COBA-IMPDIT,
            :V0COBA-PRMVG,
            :V0COBA-PRMVG,
            :V0COBA-PRMAP,
            :V0COBA-PRMAP,
            403,
            CURRENT DATE,
            0,
            '1' ,
            'GE0853S' ,
            CURRENT DATE,
            NULL,
            NULL,
            NULL,
            NULL,
            :V0FATC-DTREF,
            :V0MOVI-DTMOVTO,
            NULL,
            :V0SEGU-LOT-EMP-SEGURADO:VIND-LOT-EMP-SEG)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0MOVIMENTO VALUES ({FieldThreatment(this.V0PROP_NUM_APOLICE)}, {FieldThreatment(this.V0PROP_CODSUBES)}, {FieldThreatment(this.V0PROP_FONTE)}, {FieldThreatment(this.V0FONT_PROPAUTOM)}, '1' , {FieldThreatment(this.V0PROP_NRCERTIF)}, ' ' , {FieldThreatment(this.V0SEGU_TPINCLUS)}, {FieldThreatment(this.V0PROP_CODCLIEN)}, {FieldThreatment(this.V0SEGU_AGENCIADOR)}, 0, 0, 0, 0, 'S' , 'N' , {FieldThreatment(this.V0OPCP_PERIPGTO)}, 12, ' ' , ' ' , ' ' , 0, ' ' , 1, 1, 104, 0, ' ' , {FieldThreatment(this.V0PROP_NRMATRFUN)}, 0, ' ' , 0, ' ' , '1' , 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, {FieldThreatment(this.V0COBA_IMPMORNATU)}, {FieldThreatment(this.V0COBA_IMPMORNATU)}, {FieldThreatment(this.V0COBA_IMPMORACID)}, {FieldThreatment(this.V0COBA_IMPMORACID)}, {FieldThreatment(this.V0COBA_IMPINVPERM)}, {FieldThreatment(this.V0COBA_IMPINVPERM)}, 0, 0, 0, 0, {FieldThreatment(this.V0COBA_IMPDIT)}, {FieldThreatment(this.V0COBA_IMPDIT)}, {FieldThreatment(this.V0COBA_PRMVG)}, {FieldThreatment(this.V0COBA_PRMVG)}, {FieldThreatment(this.V0COBA_PRMAP)}, {FieldThreatment(this.V0COBA_PRMAP)}, 403, CURRENT DATE, 0, '1' , 'GE0853S' , CURRENT DATE, NULL, NULL, NULL, NULL, {FieldThreatment(this.V0FATC_DTREF)}, {FieldThreatment(this.V0MOVI_DTMOVTO)}, NULL,  {FieldThreatment((this.VIND_LOT_EMP_SEG?.ToInt() == -1 ? null : this.V0SEGU_LOT_EMP_SEGURADO))})";

            return query;
        }
        public string V0PROP_NUM_APOLICE { get; set; }
        public string V0PROP_CODSUBES { get; set; }
        public string V0PROP_FONTE { get; set; }
        public string V0FONT_PROPAUTOM { get; set; }
        public string V0PROP_NRCERTIF { get; set; }
        public string V0SEGU_TPINCLUS { get; set; }
        public string V0PROP_CODCLIEN { get; set; }
        public string V0SEGU_AGENCIADOR { get; set; }
        public string V0OPCP_PERIPGTO { get; set; }
        public string V0PROP_NRMATRFUN { get; set; }
        public string V0COBA_IMPMORNATU { get; set; }
        public string V0COBA_IMPMORACID { get; set; }
        public string V0COBA_IMPINVPERM { get; set; }
        public string V0COBA_IMPDIT { get; set; }
        public string V0COBA_PRMVG { get; set; }
        public string V0COBA_PRMAP { get; set; }
        public string V0FATC_DTREF { get; set; }
        public string V0MOVI_DTMOVTO { get; set; }
        public string V0SEGU_LOT_EMP_SEGURADO { get; set; }
        public string VIND_LOT_EMP_SEG { get; set; }

        public static void Execute(R6000_20_PROPAUTOM_DB_INSERT_1_Insert1 r6000_20_PROPAUTOM_DB_INSERT_1_Insert1)
        {
            var ths = r6000_20_PROPAUTOM_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R6000_20_PROPAUTOM_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}